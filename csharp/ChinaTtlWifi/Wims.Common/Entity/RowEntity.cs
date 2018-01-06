using System;
namespace Wims.Common.Entity
{
    public class RowEntity
    {
        public int Index { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public ControlType Type { get; set; }
        public Type DataType { get; set; }
        public string DisplayMember { get; set; }
    }
    public enum ControlType
    {
        TEXT_BOX = 0,
        COMBO_BOX = 1,
        DATE_TIME = 2
    }
}