using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDemoGetterCode : MonoBehaviour
{
    // 유니티 에디터에서 ClassDemoGameObject에 게임 오브젝트를 삽입합니다.
    public GameObject ClassDemoGameObject;

    // ClassDemoCode.cs 파일의 generateConfig 변수를 이 코드의 변수로도 추가하기 위해 변수만 정의해둡니다.
    public EmojiGenerations genCfg;

    [ContextMenu("GetEmojiData")]
    void GetDemoEmojiData()
    {
        /*  GameObject의 GetComponent<T>() 클래스는 해당 오브젝트의 T 컴포넌트 데이터를 가져옵니다.
            스크립트 컴포넌트의 소스코드의 경우 public class (클래스 이름) : MonoBehaviour 형식으로 시작하므로
            (클래스 이름)이 컴포넌트 이름이라고 생각할 수 있습니다.

            아래의 경우 ClassDemoCode의 하위에 있는 generateConfig 변수를 가져와야 하니 T 부분에 ClassDemoCode를 넣었습니다.
        */
        genCfg = ClassDemoGameObject.GetComponent<ClassDemoCode>().generateConfig;
    }
}
