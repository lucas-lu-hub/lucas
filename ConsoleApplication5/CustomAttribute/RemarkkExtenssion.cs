using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    public enum UserStatus
    {
        [Remark("正常")]
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 冻结
        /// </summary>
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2
    }
    public class RemarkAttribute : Attribute
    {
        private string _remark;
        public RemarkAttribute(string remark)
        {
            this._remark = remark;
        }
        public string GetRemark()
        {
            return _remark;
        }
    }
    public static class RemarkkExtenssion
    {
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo field = type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute)))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return value.GetRemark();
            }
        }
    }
}
