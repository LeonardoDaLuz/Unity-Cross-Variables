using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class XPrimitivesRequireds  {

    public XBrain xBrain;
    public XPrimitiveRequired[] requireds;

    public bool IsApproved()
    {
        bool findNextOr = false;
        int length = requireds.Length;
        for (int i = 0; i < length; i++)
        {
            if (!findNextOr)
            {
                bool elementApproved = false;
                switch (requireds[i].ValueType)
                {
                    case XPrimitiveRequired.valueType._bool:
                        if (requireds[i].requiredBoolValue == xBrain.xBoolList[requireds[i].xIndex].value)
                            elementApproved = true;

                        break;
                    case XPrimitiveRequired.valueType._int:
                        switch (requireds[i].NumberComparisonType)
                        {
                            case XPrimitiveRequired.numberComparisonType.equal:
                                if (requireds[i].requiredintValue == xBrain.xIntList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                            case XPrimitiveRequired.numberComparisonType.greater:
                                if (requireds[i].requiredintValue < xBrain.xIntList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                            default:
                                if (requireds[i].requiredintValue > xBrain.xIntList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                        }
                        break;
                    case XPrimitiveRequired.valueType._float:
                        switch (requireds[i].NumberComparisonType)
                        {
                            case XPrimitiveRequired.numberComparisonType.equal:
                                if (requireds[i].requiredfloatValue == xBrain.xFloatList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                            case XPrimitiveRequired.numberComparisonType.greater:
                                if (requireds[i].requiredfloatValue < xBrain.xFloatList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                            default:
                                if (requireds[i].requiredfloatValue > xBrain.xFloatList[requireds[i].xIndex].value)
                                    elementApproved = true;
                                break;
                        }
                        break;
                    default:
                        break;
                }
                if (elementApproved)
                {
                    if (i == length - 1 || requireds[i].operation == XPrimitiveRequired._Operation.Or)
                    {
                        return true;
                    }
                }
                else
                {
                    if (i == length - 1)
                    {
                        return false;
                    }
                    else if (requireds[i].operation == XPrimitiveRequired._Operation.And)
                    {
                        findNextOr = true;
                    }
                }
            }
            else
            {
                if (i == length - 1)
                {
                    return false;
                }
                if (requireds[i].operation == XPrimitiveRequired._Operation.Or)
                {
                    findNextOr = false;
                }
            }
        }

        return true;
    }

    public static implicit operator bool(XPrimitivesRequireds d)
    {
        return d.IsApproved();
    }

    [System.Serializable]
    public class XPrimitiveRequired
    {
        public int xIndex;
        public string varName;
        public bool requiredBoolValue;
        public int requiredintValue;
        public float requiredfloatValue;
        public enum valueType { _bool, _int, _float }
        public valueType ValueType;
        public enum _Operation { And, Or }
        public _Operation operation;
        public enum numberComparisonType { equal, lower, greater}
        public numberComparisonType NumberComparisonType;

        public static implicit operator bool(XPrimitiveRequired d)
        {
            Debug.LogError("This class only work under XBoolRequireds class");
            return false;
        }
    }

}


