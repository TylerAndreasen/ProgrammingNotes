# Networking Commands

1. `netsh wlan show profile "Example Network" key=clear`

This command, when given an actual network name, will list importat network properies including any password associated with the network. I noticed that after running this command more than once, the output does not include the "Key Content" field, which is the password.
