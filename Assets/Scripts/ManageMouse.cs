using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMouse : MonoBehaviour
{
    [SerializeField] private Selectable _currentSelectable;

    void LateUpdate()
    {
        RaycastMouse();
    }

    private void RaycastMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;   // Попадание на объект.

        /// При попадании перемещает поинтер в позицию хита(туда, куда направлен луч)
        if (Physics.Raycast(ray, out hit, 1000f, 7)) 
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();  
            if (selectable)
            {
                if (_currentSelectable && _currentSelectable != selectable)
                    _currentSelectable.Deselect();

                _currentSelectable = selectable;
                selectable.Select();

                if (Input.GetMouseButtonDown(0))
                    selectable.BuildMenu();
            }
            else
            {
                if (_currentSelectable)
                {
                    _currentSelectable.Deselect();
                    _currentSelectable = null;
                }
            }
        }
        else
        {
            if (_currentSelectable)
            {
                _currentSelectable.Deselect();
                _currentSelectable = null;
            }
        }
    }    
}
