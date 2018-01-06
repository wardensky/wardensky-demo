namespace Wims.Common.Mongo
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    //======================================================================
    //
    //        All rights reserved
    //
    //        filename :BaseEntity
    //        description :所有实体类的基类
    //
    //        created by lizhao@wisdombud.com at  2014-07-24 16:40:31
    //
    //======================================================================
    [Serializable]
    public class BaseEntity : MongoDbEntity, ICloneable
    {
        #region Public Properties

        [XmlAttribute("Name")]
        [Description("名称")]
        public string Name { get; set; }

        public string RE1 { get; set; }

        public string RE2 { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     浅表复制
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}