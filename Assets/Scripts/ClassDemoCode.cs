using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  아래 코드를 처리하는데 참조하는 다른 파일들이 꽤 많이 있습니다.
    먼저 아래 예제를 쭉 읽어보고 이 코드가 참조하는 다른 파일도 읽어보시면 이해가 편할 것 같습니다.
    - Configs 클래스: Assets/Configs/Configs.cs
    - Emoji 클래스: Assets/Scripts/Objects/Emoji.cs
    - EmojiGenerations 클래스: Assets/Scripts/Objects/Emoji.cs
    - PresetController 클래스: Assets/Scripts/Utilities/JsonController.cs
    - 데모용 emoji 프리셋: Assets/Presets/demo/emoji.json
    - 데모용 emojiGenerations 프리셋: Assets/Presets/demo/emojiGenerations.json
*/
public class ClassDemoCode : MonoBehaviour
{
    // EmojiGenerations 자료형은 이모지 생성에 필요한 데이터를 담을 수 있습니다.
    public EmojiGenerations generateConfig;

    // Emoji 자료형은 이모지 관리에 필요한 데이터를 담을 수 있습니다.
    public Emoji emoji;

    void Start(){}
    void Update(){}

    // [ContextMenu("MenuName")]은 유니티 에디터 상에서 컴포넌트 메뉴를 추가하는 코드입니다. 
    // 구체적인 사용 예는 https://pixelpirate.github.io/UnityEditorExtentionsBook/component-context-menu.html 를 참조하세요.
    [ContextMenu("LoadDemoGenData")]
    void LoadDemoData()
    {
        /*  아래 코드를 이해할 필요는 없습니다. 어렵다면 그냥 복사 붙여넣기 하셔도 됩니다.
            대강 Assets/Presets/demo/emojiGenerations.json 파일을 불러와서 generateConfig 변수에 데이터를 추가하는 코드라고 생각하시면 됩니다.
        */
        /*  PresetController는 Json 파일 처리를 위해 작성한 클래스입니다.
            Assets/Scripts/Utilities/JsonController.cs에서 확인할 수 있습니다.
        */
        generateConfig = PresetController.LoadJsonToObject(
            /*  Path.Combine은 System.IO를 임포트해야 사용할 수 있습니다.
                코드 첫번째줄의 using System.IO; 를 확인하세요.

                Path.Combine은 파일 경로를 합쳐주는 메서드입니다.
                Path.Combine("Assets", "Scripts")의 경우 "Assets/Scripts"로 치환됩니다.
                Assets/Scripts 대신 Path.Combine을 사용하는 이유는 운영체제에 따라 파일 경로를 표현하는 방법이 다를 수 있기 때문입니다.
                * ex) 각 운영체제의 사용자 폴더 경로 - 윈도우: C:\Users, 맥OS: /Users, 리눅스: /usr
                * 아래의 경우 Assets/Presets/demo/emojiGenerations.json 이 결과가 됩니다.
            */
            /*  Configs.PresetPath 는 Assets/Presets를 의미합니다.
                자주 사용하는 변수들을 Assets/Configs/Configs.cs에 지정해놓고 사용하고 있습니다.
            */
            Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
        /*  .ToObject<T>(); 형식으로 사용합니다. T에는 데이터타입(자료형 혹은 클래스)을 넣으면 됩니다.
            이 코드의 경우 generateConfig에 데이터를 추가하고 있으니, generateConfig의 데이터타입인 EmojiGenerations를 T에 넣었습니다.
        */
        ).ToObject<EmojiGenerations>();
    }

    [ContextMenu("LoadDemoEmojiData")]
    void LoadDemoEmojiData()
    {
        // 위 내용을 정리해서 아래와 같이 사용할 수 있습니다.
        emoji = PresetController.LoadJsonToObject(Path.Combine(Configs.PresetPath, "demo", "emoji.json")).ToObject<Emoji>();
    }

    [ContextMenu("PrintDemoEmojiData")]
    void PrintDemoEmojiData()
    {
        // 이 클래스들은 일반적인 데이터 다루듯이 다룰 수 있습니다.
        print($"ID: {emoji.id}"); // 이모지 아이디
        print($"asset: {emoji.asset}"); // 이모지 이미지 경로: 이미지 로드 코드는 제가 며칠 내로 추가하겠습니다.
        print($"thumbsup: {emoji.ondestroy}"); // 이모지 파괴 시의 점수 변화 조정 인자
    }
}
/*  이 코드를 참고해서 이모지 파괴 씬 코드를 수정해주세요.
    Assets/Presets/demo/emojiGenerations.json 파일을 이모지 파괴 씬에서 읽어들이고 이모지 생성에 읽어들인 값을 적용하는 정도면 충분할 것 같습니다.
*/
