using UnityEngine;

public class InputController : MonoBehaviour
{
    #region -- 變數參考區 --

    /// <summary>
    /// 手的方向
    /// </summary>
    private DirectionDefine.Direction handDirection;

    /// <summary>
    /// 滑鼠左鍵
    /// </summary>
    private const int LeftMouseButton = 0;

    //紀錄手指觸碰位置
    private Vector2 touchScreenPos = new Vector2();

    #endregion

    #region -- 初始化/運作 --

    private void Update()
    {
        handDirection = DirectionDefine.Direction.None;

        #if UNITY_EDITOR || UNITY_STANDALONE
                MouseInput();   // 滑鼠偵測
        #elif UNITY_ANDROID
		        MobileInput();  // 觸碰偵測
        #endif
    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 偵測滑鼠輸入
    /// </summary>
    void MouseInput()
    {
        if (GetLeftMouseClickDown())
        {
            touchScreenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (GetLeftMouseClickUp())
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            handDirection = HandDirection(touchScreenPos, pos);

            if (touchScreenPos == pos)
                Debug.Log("Click");
            else
                Debug.Log($"handDirection: {handDirection}");
        }
    }

    /// <summary>
    /// 手機偵測觸碰輸入
    /// </summary>
    void MobileInput()
    {
        if (Input.touchCount <= 0)
            return;

        //1個手指觸碰螢幕
        if (Input.touchCount == 1)
        {

            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                //紀錄觸碰位置
                touchScreenPos = Input.touches[0].position;

                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
            }


            //手指離開螢幕
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Debug.Log("Ended");
                Vector2 pos = Input.touches[0].position;

                DirectionDefine.Direction handDirection = HandDirection(touchScreenPos, pos);
                Debug.Log($"handDirection: {handDirection}");
            }
            //攝影機縮放，如果1個手指以上觸碰螢幕
        }
        else if (Input.touchCount > 1)
        {

            //記錄兩個手指位置
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            //記錄兩個手指移動距離
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];

                if (touch.phase == TouchPhase.Ended)
                    break;

                if (touch.phase == TouchPhase.Moved)
                {
                    //每次都重置
                    float move = 0;

                    //觸碰一點
                    if (i == 0)
                    {
                        finger1 = touch.position;
                        move1 = touch.deltaPosition;
                        //另一點
                    }
                    else
                    {
                        finger2 = touch.position;
                        move2 = touch.deltaPosition;

                        //取最大X
                        if (finger1.x > finger2.x)
                        {
                            move = move1.x;
                        }
                        else
                        {
                            move = move2.x;
                        }

                        //取最大Y，並與取出的X累加
                        if (finger1.y > finger2.y)
                        {
                            move += move1.y;
                        }
                        else
                        {
                            move += move2.y;
                        }

                        //當兩指距離越遠，Z位置加的越多，相反之
                        Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
                    }
                }
            }//end for
        }//end else if 
    }// 方法結束

    /// <summary>
    /// 取得手滑的方向
    /// </summary>
    /// <returns></returns>
    public DirectionDefine.Direction GetHandDirection()
    {
        return handDirection;
    }

    public bool GetSlideUp()
    {
        if(handDirection == DirectionDefine.Direction.Up) return true;
        return false;
    }

    /// <summary>
    /// 是否按下滑鼠左鍵
    /// </summary>
    public bool GetLeftMouseClickDown()
    {
        return Input.GetMouseButtonDown(LeftMouseButton);
    }

    /// <summary>
    /// 是否放開滑鼠左鍵
    /// </summary>
    public bool GetLeftMouseClickUp()
    {
        return Input.GetMouseButtonUp(LeftMouseButton);
    }

    /// <summary>
    /// 判斷手滑的方向
    /// </summary>
    /// <param name="StartPos">一開始觸碰的點</param>
    /// <param name="EndPos">手指離開的點</param>
    /// <returns></returns>
    DirectionDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
    {

        //手指水平移動
        if (Mathf.Abs(StartPos.x - EndPos.x) > Mathf.Abs(StartPos.y - EndPos.y))
        {
            if (StartPos.x > EndPos.x)
            {
                //手指向左滑動
                handDirection = DirectionDefine.Direction.Left;
            }
            else
            {
                //手指向右滑動
                handDirection = DirectionDefine.Direction.Right;
            }
        }
        else if (Mathf.Abs(StartPos.x - EndPos.x) < Mathf.Abs(StartPos.y - EndPos.y))
        {
            if (touchScreenPos.y > EndPos.y)
            {
                //手指向下滑動
                handDirection = DirectionDefine.Direction.Down;
            }
            else
            {
                //手指向上滑動
                handDirection = DirectionDefine.Direction.Up;
            }
        }
        else handDirection = DirectionDefine.Direction.None;
        return handDirection;
    }

    #endregion
}
