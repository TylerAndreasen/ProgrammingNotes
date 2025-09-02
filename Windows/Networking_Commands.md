# Networking Commands

1. `netsh wlan show profile "Example Network" key=clear`

This command, when given an actual network name, will list important network properies including any password associated with the network. I noticed that after running this command more than once, the output does not include the "Key Content" field, which is the password, so you may need to restart the terminal if you have to run the command again.
