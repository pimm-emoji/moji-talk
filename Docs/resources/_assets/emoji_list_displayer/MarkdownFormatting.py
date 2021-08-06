import re
from os import listdir
for f in listdir():
    if f == 'app.py' or len(f) < 2:
        continue
    print('| {} |  | `{}` | `{}` |'.format(
        eval('chr({})'.format(
            '0x{}'.format(re.split('[.-]', f)[0]))
        ),
        f,
        'U+{}'.format(f.replace('.svg.png', '').upper())
    ))