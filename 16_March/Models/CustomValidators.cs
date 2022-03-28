using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace _16_March.Models
{
    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) <= 0)
            {
                return false;
            }
            return true;
        }
    }


    public class CheckString : ValidationAttribute
    {
        private SerializationInfo regex;
        /// <summary>
        /// Parameter 'value' will be set by the value entered
        /// for the property from UI where the current attribute
        /// is applied
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            Regex re = new Regex("[A-Z][A-Za-z ]+[A-Za-z]$");
            if (re.IsMatch(Convert.ToString(value)))
            {
                return true;
            }
            return false;
        }
    }












}
