# System.IO.Ports.SerialPorts is seriously broken, so we use a custom serial lib  
using namespace Serially.Core
Add-Type -Path "./Serially.Core.dll"

function try_open_port([SerialPort] $port, [SerialConfig] $config) 
{
    try
    {
        $port.Open($config) | Await-Task
    }
    catch [Exception]
    {
        #Write-Host $_.Exception.Message
    }

    return $port.IsOpen;
}

function wait_for_port([System.String] $name) 
{
    $config = New-Object SerialConfig
    $config.PortName = $name
    $config.BaudRate = 1000000
    $script:port = New-Object SerialPort

    $activity = "Waiting for $($config.PortName)";
    Write-Output $activity
    $progress = "..."

    while (!(try_open_port $port $config))
    {
        Write-Progress $activity $progress
        $progress += "."
        Start-Sleep -s 1
    }

    Write-Progress $activity -Completed
    Write-Output "Opened $($port.PortName)"
}

function tail_log([System.String] $port_name) 
{
    try
    {
        wait_for_port($port_name)

        do {
            $buffer = $script:port.ReadExisting()
            Write-Host -NoNewline $buffer
        } while ($script:port.IsOpen)
    }
    finally
    {
        if ($script:port.IsOpen)
        {
            $script:port.Close()    
        }
    }
}

$char_null = [char]00
$esc = [char]27 # ESC character
$left_bracket = [char]91 # [
$char_delete = [char]127

# Map the key key to an ASCII character if possible.
# Return char_null if the given keypress either does not need mapping to an ASCII keycode
# or cannot be represented with a single ASCII character, in which case it should be escaped.
# e.g. ConsoleKey 'A' == 65 and 65 is ASCII for 'A', 
# but ConsoleKey 'Delete' == 46 which should be 127 in ASCII.
function map_ascii([System.ConsoleKey] $key)
{
    $is_delete = $keyInfo.Key -eq [System.ConsoleKey]::Delete

    if ($is_delete)
    {
        return $char_delete
    } 

    return $char_null
}

# Return char_null if the given keypress is not representable as an ASCII escape sequence.
# Else return the character which when prefixed by "ESC[" communicates the given keypress 
function escape_ascii([System.ConsoleKey] $key)
{
    $is_arrow_up = $keyInfo.Key -eq [System.ConsoleKey]::UpArrow 
    $is_arrow_down = $keyInfo.Key -eq [System.ConsoleKey]::DownArrow 
    $is_arrow_right = $keyInfo.Key -eq [System.ConsoleKey]::RightArrow 
    $is_arrow_left = $keyInfo.Key -eq [System.ConsoleKey]::LeftArrow 

    $char = $char_null

    if ($is_arrow_up)
    {
        $char = 'A'
    }  
    if ($is_arrow_down)
    {
        $char = 'B'
    }
    if ($is_arrow_right)
    {
        $char = 'C'
    }
    if ($is_arrow_left)
    {
        $char = 'D'
    }
    if ($is_delete)
    {
        $char = 'D'
    }

    return $char
}

function close_port()
{
    if ($script:port.IsOpen)
    {
        $script:port.Close()    
    }
}

function run_cli([System.String] $port_name) 
{
    try
    {
        wait_for_port($port_name)

        do 
        {
            Write-Host -NoNewline $script:port.ReadExisting()

            if (![Console]::KeyAvailable)
            {
                continue
            }

            $keyInfo = [Console]::ReadKey($true)

            $escaped_char = escape_ascii($keyInfo.Key)
            $mapped_char = map_ascii($keyInfo.Key)
            
            $escaped = !$escaped_char -eq $char_null;
            $mapped = !$mapped_char -eq $char_null;

            # Escaped character
            if ($escaped)
            {
                # Generate ASCII Escape sequence e.g. ESC[A => Arrow Up
                $script:port.WriteChar($esc)
                $script:port.WriteChar($left_bracket)
                $script:port.WriteChar($escaped_char)
                continue
            }

            # Mapped character
            if ($mapped)
            {
                # This char must be mapped to ASCII e.g. ConsoleKey Delete == 46 and ASCII DEL == 127
                $script:port.WriteChar($mapped_char)
                continue
            }

            # No mapping or escaping needed
            $script:port.WriteChar($keyInfo.KeyChar)

        } while ($script:port.IsOpen)
    }
    finally
    {
        close_port
    }
}

