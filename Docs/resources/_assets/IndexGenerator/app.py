import json
import os

def processing(root: str, pre: str):
    files = os.listdir(root)
    nf = []
    for file in files:
        if '.meta' not in file:
            nf += [os.path.join(root, file).replace('../../../../Assets/Resources/', '')]
    return nf

if __name__ == '__main__':
    if not os.path.isdir('results'):
        os.mkdir('results')
    for s in ['Positives', 'Medium', 'Negatives']:
        for path in processing('../../../../Assets/Resources/Emojis/'+s, ''):
            d = {
                'id': path.split('/')[2].replace('.png', ''),
                'asset': path,
                'ondestroy': 0
            }
            with open('results/{}.json'.format(d['id']), 'w', encoding='utf-8') as f:
                f.write(json.dumps(d, indent=2))
