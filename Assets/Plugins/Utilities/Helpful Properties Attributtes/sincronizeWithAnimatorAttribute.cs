using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sincronizeWithAnimator : PropertyAttribute
{
        public bool hide;
        public sincronizeWithAnimator(bool hide=false)
        {
            this.hide = hide;
        }
    
}
