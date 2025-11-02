using System;

namespace NET.App.API.DataModel
{
    /// <summary>
    /// Represents a Revit category
    /// </summary>
    public class CategoryData
    {
        /// <summary>
        /// The string representation of the BuiltInCategory Enum
        /// </summary>
        public string BICValue { get; }

        /// <summary>
        /// The category name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The name of the parent category if any
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// If this category is architectural
        /// </summary>
        public bool IsArchitectural { get; }

        /// <summary>
        /// If this category is structural
        /// </summary>
        public bool IsStructural { get; }

        /// <summary>
        /// If this category is MEP
        /// </summary>
        public bool IsMEP { get; }

        /// <summary>
        /// If this category is annotative
        /// </summary>
        public bool IsAnnotative { get; }

        /// <summary>
        /// If this category is datum
        /// </summary>
        public bool IsDatum { get; }

        /// <summary>
        /// If this category is a view category
        /// </summary>
        public bool IsView { get; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="bicValue">The string version of the BuiltInCategory enum</param>
        /// <param name="name">The category name</param>
        /// <param name="parentName">The parent category name, if any</param>
        /// <param name="architectural">If this is architectural</param>
        /// <param name="structural">If this is structural</param>
        /// <param name="mep">If this is MEP</param>
        /// <param name="annotative">If this is annotative</param>
        /// <param name="datum">If this is datum</param>
        /// <param name="view">If this is view related</param>
        public CategoryData(string bicValue, string name, string parentName, bool architectural, bool structural, bool mep, bool annotative, bool datum, bool view)
        {
            BICValue = bicValue ?? throw new ArgumentNullException("bicValue");
            Name = name ?? throw new ArgumentNullException("name");
            ParentName = parentName;
            IsArchitectural = architectural;
            IsStructural = structural;
            IsMEP = mep;
            IsAnnotative = annotative;
            IsDatum = datum;
            IsView = view;
        }
    }
}