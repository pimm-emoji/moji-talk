using System.IO;
using UnityEngine;

class ChattingWrapperRect
{
    public static RectAnchorsChatting Left;
    public static RectAnchorsChatting Right;

    static ChattingWrapperRect()
    {
        Left = new RectAnchorsChatting(new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 0));
        Right = new RectAnchorsChatting(new Vector2(1, 1), new Vector2(1, 1), new Vector2(1, 1), new Vector2(1, 0));
    }
}

class RectVariables
{
    public static RectAnchors TopLeft;
    public static RectAnchors TopCenter;
    public static RectAnchors TopRight;
    public static RectAnchors MiddleLeft;
    public static RectAnchors MiddleCenter;
    public static RectAnchors MiddleRight;
    public static RectAnchors BottomLeft;
    public static RectAnchors BottomCenter;
    public static RectAnchors BottomRight;
    public static RectAnchors HorizontalStretchLeft;
    public static RectAnchors HorizontalStretchCenter;
    public static RectAnchors HorizontalStretchRight;
    public static RectAnchors TopVerticalStretch;
    public static RectAnchors MiddleVerticalStretch;
    public static RectAnchors BottomVerticalStretch;

    static RectVariables()
    {
        TopLeft                 = new RectAnchors(new Vector2(0f,  1f),     new Vector2(0f,  1f),   new Vector2(0f,   1f));
        TopCenter               = new RectAnchors(new Vector2(.5f, 1f),     new Vector2(.5f, 1f),   new Vector2(.5f,  1f));
        TopRight                = new RectAnchors(new Vector2(1f,  1f),     new Vector2(1f,  1f),   new Vector2(1f,   1f));
        MiddleLeft              = new RectAnchors(new Vector2(0f,  .5f),    new Vector2(0f,  .5f),  new Vector2(0f,  .5f));
        MiddleCenter            = new RectAnchors(new Vector2(.5f, .5f),    new Vector2(.5f, .5f),  new Vector2(.5f, .5f));
        MiddleRight             = new RectAnchors(new Vector2(1f,  .5f),    new Vector2(1f,  .5f),  new Vector2(1f,  .5f));
        BottomLeft              = new RectAnchors(new Vector2(0f,  0f),     new Vector2(0f,  0f),   new Vector2(0f,  0f));
        BottomCenter            = new RectAnchors(new Vector2(.5f, 0f),     new Vector2(.5f, 0f),   new Vector2(.5f, 0f));
        BottomRight             = new RectAnchors(new Vector2(1f,  0f),     new Vector2(1f,  0f),   new Vector2(1f,  0f));
        HorizontalStretchLeft   = new RectAnchors(new Vector2(0f,  0f),     new Vector2(0f,  1f),   new Vector2(0f,  0f));
        HorizontalStretchCenter = new RectAnchors(new Vector2(.5f, 0f),     new Vector2(.5f, 1f),   new Vector2(.5f, 0f));
        HorizontalStretchRight  = new RectAnchors(new Vector2(1f,  0f),     new Vector2(1f,  1f),   new Vector2(1f,  0f));
        TopVerticalStretch      = new RectAnchors(new Vector2(0f,  1f),     new Vector2(1f,  1f),   new Vector2(0f,  0f));
        MiddleVerticalStretch   = new RectAnchors(new Vector2(0f,  .5f),    new Vector2(1f,  .5f),  new Vector2(0f,  .5f));
        BottomVerticalStretch   = new RectAnchors(new Vector2(0f,  0f),     new Vector2(1f,  0f),   new Vector2(0f,  1f));
    }
}

[System.Serializable]
public class RectAnchors
{
    public Vector2 anchorMin;
    public Vector2 anchorMax;
    public Vector2 pivot;
    
    public RectAnchors(Vector2 AnchorMin, Vector2 AnchorMax, Vector2 Pivot)
    {
        anchorMin = AnchorMin;
        anchorMax = AnchorMax;
        pivot = Pivot;
    }
}

[System.Serializable]
public class RectAnchorsChatting : RectAnchors
{
    public Vector2 childPivot;
    public RectAnchorsChatting(Vector2 AnchorMin, Vector2 AnchorMax, Vector2 Pivot, Vector2 ChildPivot)
    : base(AnchorMin, AnchorMax, Pivot)
    {
        childPivot = ChildPivot;
    }
}
