import os
while True:
    line = input()
    if not line:
        break
    line = line.split('|')
    os.rename(line[3].replace(' ', '').replace('`', ''), line[2].replace(' ', '')+'.png')