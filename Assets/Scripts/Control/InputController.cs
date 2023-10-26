using UnityEngine;
/// <summary>
/// ���Ѥ�V���T�|
/// </summary>
public class DirectionDefine
{
    /// <summary>
    /// ��V���T�|
    /// </summary>
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }
}

public class InputController : MonoBehaviour
{
    #region -- �ѼưѦҰ� --

    /// <summary>
    /// �⪺��V
    /// </summary>
    private DirectionDefine.Direction handDirection;

    /// <summary>
    /// �ƹ�����
    /// </summary>
    private const int LeftMouseButton = 0;

    //�������Ĳ�I��m
    private Vector2 touchScreenPos = new Vector2();

    #endregion

    #region -- ��l��/�B�@ --

    private void Update()
    {
        handDirection = DirectionDefine.Direction.None;

        #if UNITY_EDITOR || UNITY_STANDALONE
                MouseInput();   // �ƹ�����
        #elif UNITY_ANDROID
		        MobileInput();  // Ĳ�I����
        #endif
    }

    #endregion

    #region -- ��k�ѦҰ� --

    /// <summary>
    /// �����ƹ���J
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
    /// �������Ĳ�I��J
    /// </summary>
    void MobileInput()
    {
        if (Input.touchCount <= 0)
            return;

        //1�Ӥ��Ĳ�I�ù�
        if (Input.touchCount == 1)
        {

            //�}�lĲ�I
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Began");
                //����Ĳ�I��m
                touchScreenPos = Input.touches[0].position;

                //�������
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Debug.Log("Moved");
                //������v��
                //Camera.main.transform.Translate (new Vector3 (-Input.touches [0].deltaPosition.x * Time.deltaTime, -Input.touches [0].deltaPosition.y * Time.deltaTime, 0));
            }


            //������}�ù�
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Debug.Log("Ended");
                Vector2 pos = Input.touches[0].position;

                DirectionDefine.Direction handDirection = HandDirection(touchScreenPos, pos);
                Debug.Log($"handDirection: {handDirection}");
            }
            //��v���Y��A�p�G1�Ӥ���H�WĲ�I�ù�
        }
        else if (Input.touchCount > 1)
        {

            //�O����Ӥ����m
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            //�O����Ӥ�����ʶZ��
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //�O�_�O�p��2�IĲ�I
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];

                if (touch.phase == TouchPhase.Ended)
                    break;

                if (touch.phase == TouchPhase.Moved)
                {
                    //�C�������m
                    float move = 0;

                    //Ĳ�I�@�I
                    if (i == 0)
                    {
                        finger1 = touch.position;
                        move1 = touch.deltaPosition;
                        //�t�@�I
                    }
                    else
                    {
                        finger2 = touch.position;
                        move2 = touch.deltaPosition;

                        //���̤jX
                        if (finger1.x > finger2.x)
                        {
                            move = move1.x;
                        }
                        else
                        {
                            move = move2.x;
                        }

                        //���̤jY�A�ûP���X��X�֥[
                        if (finger1.y > finger2.y)
                        {
                            move += move1.y;
                        }
                        else
                        {
                            move += move2.y;
                        }

                        //�����Z���V���AZ��m�[���V�h�A�ۤϤ�
                        Camera.main.transform.Translate(0, 0, move * Time.deltaTime);
                    }
                }
            }//end for
        }//end else if 
    }// ��k����

    /// <summary>
    /// ���o��ƪ���V
    /// </summary>
    /// <returns></returns>
    public DirectionDefine.Direction GetHandDirection()
    {
        return handDirection;
    }

    /// <summary>
    /// �O�_���U�ƹ�����
    /// </summary>
    public bool GetLeftMouseClickDown()
    {
        return Input.GetMouseButtonDown(LeftMouseButton);
    }

    /// <summary>
    /// �O�_��}�ƹ�����
    /// </summary>
    public bool GetLeftMouseClickUp()
    {
        return Input.GetMouseButtonUp(LeftMouseButton);
    }

    /// <summary>
    /// �P�_��ƪ���V
    /// </summary>
    /// <param name="StartPos">�@�}�lĲ�I���I</param>
    /// <param name="EndPos">������}���I</param>
    /// <returns></returns>
    DirectionDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
    {

        //�����������
        if (Mathf.Abs(StartPos.x - EndPos.x) > Mathf.Abs(StartPos.y - EndPos.y))
        {
            if (StartPos.x > EndPos.x)
            {
                //����V���ư�
                handDirection = DirectionDefine.Direction.Left;
            }
            else
            {
                //����V�k�ư�
                handDirection = DirectionDefine.Direction.Right;
            }
        }
        else
        {
            if (touchScreenPos.y > EndPos.y)
            {
                //����V�U�ư�
                handDirection = DirectionDefine.Direction.Down;
            }
            else
            {
                //����V�W�ư�
                handDirection = DirectionDefine.Direction.Up;
            }
        }
        return handDirection;
    }

    #endregion
}
