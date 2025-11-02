using NET.App.API;
using NET.App.API.Converters;
using NET.App.API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.APP.API.DataModel
{
    public class Filter 
    {
        //private Check _check;

        private bool _selected;

        private bool _userDefined;

        private FilterEnums.Operators _op;

        private FilterEnums.Categories _cat;

        private string _prop = string.Empty;

        private FilterEnums.Conditions _cond;

        private string _val = string.Empty;

        private string _fieldTitle;

        private FilterEnums.ValidationTypes _validation;

        private FilterEnums.UnitClasses _unitClass;

        private FilterEnums.Units _unit;

        private int _indentLevel;

        private bool _caseInsensitive;

        /// <summary>
        /// The GUID of this filter
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The check this filter belongs to
        /// </summary>
        //public Check Check
        //{
        //    get
        //    {
        //        return _check;
        //    }
        //    set
        //    {
        //        if (_check != value)
        //        {
        //            _check = value;
        //            //OnPropertyChanged("Check");
        //        }
        //    }
        //}

        /// <summary>
        /// The operator for this filter
        /// </summary>
        [JsonConverter(typeof(EnumJsonConvert<FilterEnums.Operators>))]
        [JsonProperty(propertyName: "operator")]
        public FilterEnums.Operators Operator
        {
            get
            {
                return _op;
            }
            set
            {
                if (_op != value)
                {
                    _op = value;
                    //OnPropertyChanged("Operator");
                    //OnPropertyChanged("ValueOptions");
                }
            }
        }

        /// <summary>
        /// The category of this filter
        /// </summary>
        [JsonConverter(typeof(EnumJsonConvert<FilterEnums.Categories>))]
        [JsonProperty(propertyName: "category")]
        public FilterEnums.Categories Category
        {
            get
            {
                return _cat;
            }
            set
            {
                if (_cat != value)
                {
                    _cat = value;
                    //OnPropertyChanged("Category");
                    //OnPropertyChanged("PropertyOptions");
                    //OnPropertyChanged("ValueOptions");
                    //OnPropertyChanged("AllowCustomProperty");
                    //OnPropertyChanged("AllowCustomValue");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("ConditionOptions");
                    //OnPropertyChanged("ShowUnitDesignators");
                    //OnPropertyChanged("AllowCaseInsensitive");
                    if (!PropertyOptions.Contains(Property) && PropertyOptions.Count > 0 && !AllowCustomProperty)
                    {
                        Property = PropertyOptions[0];
                    }
                }
            }
        }

        /// <summary>
        /// The property this filter works on
        /// </summary>
        [JsonProperty(propertyName: "property")]
        public string Property
        {
            get
            {
                return _prop;
            }
            set
            {
                if (_prop == value)
                {
                    return;
                }
                _prop = value.Trim();
                //OnPropertyChanged("ValueOptions");
                //OnPropertyChanged("ConditionOptions");
                //OnPropertyChanged("Property");
                //OnPropertyChanged("AllowCustomValue");
                //OnPropertyChanged("DisplayText");
                //OnPropertyChanged("AllowCaseInsensitive");
                if (!ConditionOptions.Contains(Condition) && ConditionOptions.Count > 0)
                {
                    Condition = Enum.GetValues(typeof(FilterEnums.Conditions)).Cast<FilterEnums.Conditions>().FirstOrDefault((FilterEnums.Conditions x) => x == ConditionOptions[0]);
                }
                //OnPropertyChanged("Condition");
                //if (!ValueOptions.Contains(Value) && ValueOptions.Count > 0 && !AllowCustomValue)
                //{
                //    Value = ValueOptions[0];
                //}
            }
        }

        /// <summary>
        /// The condition for combining filters
        /// </summary>
        [JsonConverter(typeof(EnumJsonConvert<FilterEnums.Conditions>))]
        [JsonProperty(propertyName: "condition")]
        public FilterEnums.Conditions Condition
        {
            get
            {
                return _cond;
            }
            set
            {
                if (_cond != value)
                {
                    _cond = value;
                    //OnPropertyChanged("Condition");
                    //OnPropertyChanged("ValueOptions");
                    //OnPropertyChanged("AllowCustomValue");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("ShowUnitDesignators");
                    //OnPropertyChanged("AllowCaseInsensitive");
                    //if (!ValueOptions.Contains(Value) && ValueOptions.Count > 0 && !AllowCustomValue)
                    //{
                    //    Value = ValueOptions[0];
                    //}
                }
            }
        }

        /// <summary>
        /// The filter value,value need to selected in propertyOptions
        /// </summary>
        [JsonProperty(propertyName:"value")]
        public string Value
        {
            get
            {
                return _val;
            }
            set
            {
                if (!(_val == value))
                {
                    _val = value;
                    //OnPropertyChanged("Value");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("ConvertedValue");
                }
            }
        }

        /// <summary>
        /// The converted filter value
        /// </summary>
        //public string ConvertedValue
        //{
        //    get
        //    {
        //        if (Unit == Enums.Units.None)
        //        {
        //            return Value;
        //        }
        //        if (!double.TryParse(Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        //        {
        //            return string.Empty;
        //        }
        //        return Math.Round(UnitConverter.ConvertFromDbUnits(result, Unit, UnitClass), 4).ToString(CultureInfo.CurrentCulture);
        //    }
        //    set
        //    {
        //        if (Unit == Enums.Units.None)
        //        {
        //            Value = value;
        //            return;
        //        }
        //        double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out var result);
        //        Value = UnitConverter.ConvertToDbUnits(result, Unit, UnitClass).ToString(CultureInfo.InvariantCulture);
        //    }
        //}

        /// <summary>
        /// The text to display for this filter
        /// </summary>
        //public string DisplayText
        //{
        //    get
        //    {
        //        string empty = string.Empty;
        //        empty += (FieldIsUserDefined ? MCResources.Label_ValueFromUser : MCResources.Label_ValueFromCode);
        //        empty += ConvertedValue.GetDisplayValue();
        //        if (Unit != 0)
        //        {
        //            empty = empty + ((Unit == Enums.Units.Inches || Unit == Enums.Units.Feet) ? string.Empty : " ") + UnitConverter.GetUnitTag(Unit, UnitClass);
        //        }
        //        return empty;
        //    }
        //}

        /// <summary>
        /// The validation type of this filter
        /// </summary>
        public FilterEnums.ValidationTypes Validation
        {
            get
            {
                return _validation;
            }
            set
            {
                if (_validation != value)
                {
                    _validation = value;
                    //OnPropertyChanged("Validation");
                    //OnPropertyChanged("FieldIsTextbox");
                    //OnPropertyChanged("FieldIsCheckbox");
                }
            }
        }

        /// <summary>
        /// If the field for this filter is user defined
        /// </summary>
        public bool FieldIsUserDefined
        {
            get
            {
                return _userDefined;
            }
            set
            {
                if (_userDefined != value)
                {
                    _userDefined = value;
                    //OnPropertyChanged("FieldIsUserDefined");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("ShowUnitDesignators");
                }
            }
        }

        /// <summary>
        /// If the field should be displayed as a checkbox
        /// </summary>
        //public bool FieldIsCheckbox => _validation == FilterEnums.ValidationTypes.Boolean;

        /// <summary>
        /// If the field should be displayed as a text box
        /// </summary>
        //public bool FieldIsTextbox => _validation != FilterEnums.ValidationTypes.Boolean;

        /// <summary>
        /// The title of the field associated with this check - only relevant if the check has
        /// a field associated with it (check the HasField property)
        /// </summary>
        public string FieldTitle
        {
            get
            {
                return _fieldTitle;
            }
            set
            {
                if (!(_fieldTitle == value))
                {
                    _fieldTitle = value;
                    //OnPropertyChanged("FieldTitle");
                }
            }
        }

        /// <summary>
        /// If the operator should be shown for this filter
        /// </summary>
       // public bool ShowOperator => _check.Filters.IndexOf(this) != 0;

        /// <summary>
        /// If this filter allows custom properties
        /// </summary>
        public bool AllowCustomProperty
        {
            get
            {
                if (Category != FilterEnums.Categories.Parameter && Category != 0 && Category != FilterEnums.Categories.PhaseStatus && Category != FilterEnums.Categories.APIParameter)
                {
                    return Category == FilterEnums.Categories.HostParameter;
                }
                return true;
            }
        }

        /// <summary>
        /// If this filter allows custom values
        /// </summary>
        public bool AllowCustomValue
        {
            get
            {
                if (Category == FilterEnums.Categories.Category && Property != "Name")
                {
                    return false;
                }
                if (Category == FilterEnums.Categories.TypeOrInstance || Category == FilterEnums.Categories.PhaseStatus || Category == FilterEnums.Categories.StructuralType || Category == FilterEnums.Categories.Redundant)
                {
                    return false;
                }
                if (Condition == FilterEnums.Conditions.Defined || Condition == FilterEnums.Conditions.Undefined || Condition == FilterEnums.Conditions.HasValue || Condition == FilterEnums.Conditions.HasNoValue || Condition == FilterEnums.Conditions.Duplicated)
                {
                    return false;
                }
                if (Property == "Is In Place" || Property == "Is Defined")
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// If case insensitive setting is allowed
        /// </summary>
        public bool AllowCaseInsensitive
        {
            get
            {
                if (UnitClass == FilterEnums.UnitClasses.None && AllowCustomValue)
                {
                    if (Condition != 0 && Condition != FilterEnums.Conditions.NotEqual && Condition != FilterEnums.Conditions.Contains)
                    {
                        return Condition == FilterEnums.Conditions.DoesNotContain;
                    }
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// If comparisons are case insensitive
        /// </summary>
        public bool CaseInsensitive
        {
            get
            {
                return _caseInsensitive;
            }
            set
            {
                if (_caseInsensitive != value)
                {
                    _caseInsensitive = value;
                    //OnPropertyChanged("CaseInsensitive");
                }
            }
        }

        /// <summary>
        /// If this filter is currently selected
        /// </summary>
        //public bool IsSelected
        //{
        //    get
        //    {
        //        return _selected;
        //    }
        //    set
        //    {
        //        if (_selected != value)
        //        {
        //            _selected = value;
        //            //OnPropertyChanged("IsSelected");
        //        }
        //    }
        //}

        /// <summary>
        /// Currently available options for conditions
        /// </summary>
        public List<FilterEnums.Conditions> ConditionOptions
        {
            get
            {
                List<FilterEnums.Conditions> list = new List<FilterEnums.Conditions> { FilterEnums.Conditions.Equal };
                switch (Category)
                {
                    case FilterEnums.Categories.Room:
                    case FilterEnums.Categories.Space:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        if (Property == "Is Defined")
                        {
                            return list;
                        }
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.Defined);
                        list.Add(FilterEnums.Conditions.Undefined);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        return list;
                    case FilterEnums.Categories.Category:
                        if (Property == "Name")
                        {
                            list.Add(FilterEnums.Conditions.NotEqual);
                            list.Add(FilterEnums.Conditions.Contains);
                            list.Add(FilterEnums.Conditions.DoesNotContain);
                        }
                        else
                        {
                            list.Clear();
                            list.Add(FilterEnums.Conditions.Included);
                        }
                        return list;
                    case FilterEnums.Categories.PhaseDemolished:
                    case FilterEnums.Categories.DesignOption:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.Defined);
                        list.Add(FilterEnums.Conditions.Undefined);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        return list;
                    case FilterEnums.Categories.View:
                        if (Property == "Is Defined")
                        {
                            list.Add(FilterEnums.Conditions.NotEqual);
                        }
                        else
                        {
                            list.Add(FilterEnums.Conditions.NotEqual);
                            list.Add(FilterEnums.Conditions.Contains);
                            list.Add(FilterEnums.Conditions.DoesNotContain);
                            list.Add(FilterEnums.Conditions.Defined);
                            list.Add(FilterEnums.Conditions.Undefined);
                            list.Add(FilterEnums.Conditions.WildCard);
                            list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        }
                        return list;
                    case FilterEnums.Categories.PhaseCreated:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.Defined);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        return list;
                    case FilterEnums.Categories.Family:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        if (Property == "Is In Place")
                        {
                            return list;
                        }
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        return list;
                    case FilterEnums.Categories.Workset:
                    case FilterEnums.Categories.Type:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        return list;
                    case FilterEnums.Categories.TypeOrInstance:
                        return list;
                    case FilterEnums.Categories.Level:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        if (Property == "Name")
                        {
                            list.Add(FilterEnums.Conditions.Contains);
                            list.Add(FilterEnums.Conditions.DoesNotContain);
                            list.Add(FilterEnums.Conditions.Defined);
                            list.Add(FilterEnums.Conditions.Undefined);
                            list.Add(FilterEnums.Conditions.WildCard);
                            list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        }
                        else
                        {
                            list.Add(FilterEnums.Conditions.GreaterThan);
                            list.Add(FilterEnums.Conditions.LessThan);
                            list.Add(FilterEnums.Conditions.GreaterOrEqual);
                            list.Add(FilterEnums.Conditions.LessOrEqual);
                        }
                        return list;
                    case FilterEnums.Categories.Parameter:
                    case FilterEnums.Categories.APIParameter:
                    case FilterEnums.Categories.HostParameter:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        list.Add(FilterEnums.Conditions.GreaterThan);
                        list.Add(FilterEnums.Conditions.LessThan);
                        list.Add(FilterEnums.Conditions.GreaterOrEqual);
                        list.Add(FilterEnums.Conditions.LessOrEqual);
                        list.Add(FilterEnums.Conditions.Contains);
                        list.Add(FilterEnums.Conditions.DoesNotContain);
                        list.Add(FilterEnums.Conditions.Defined);
                        list.Add(FilterEnums.Conditions.Undefined);
                        list.Add(FilterEnums.Conditions.HasValue);
                        list.Add(FilterEnums.Conditions.HasNoValue);
                        list.Add(FilterEnums.Conditions.WildCard);
                        list.Add(FilterEnums.Conditions.WildCardNoMatch);
                        list.Add(FilterEnums.Conditions.Duplicated);
                        if (Category == FilterEnums.Categories.APIParameter)
                        {
                            return list;
                        }
                        list.Add(FilterEnums.Conditions.MatchesParameter);
                        list.Add(FilterEnums.Conditions.DoesNotMatchParameter);
                        return list;
                    case FilterEnums.Categories.PhaseStatus:
                    case FilterEnums.Categories.StructuralType:
                        list.Add(FilterEnums.Conditions.NotEqual);
                        return list;
                    case FilterEnums.Categories.APIType:
                    case FilterEnums.Categories.Redundant:
                    case FilterEnums.Categories.Host:
                        return list;
                    default:
                        return Enum.GetValues(typeof(FilterEnums.Conditions)).Cast<FilterEnums.Conditions>().ToList();
                }
            }
        }

        /// <summary>
        /// Currently available options for properties
        /// </summary>
        public List<string> PropertyOptions
        {
            get
            {
                List<string> list = new List<string>();
                switch (Category)
                {
                    case FilterEnums.Categories.Room:
                    case FilterEnums.Categories.Space:
                        list.Add("Name");
                        list.Add("Number");
                        list.Add("Is Defined");
                        return list;
                    case FilterEnums.Categories.Category:
                        list.Add("Name");
                        list.AddRange(SharedData.BuiltInCategoryValues);
                        return list;
                    case FilterEnums.Categories.PhaseCreated:
                    case FilterEnums.Categories.PhaseDemolished:
                    case FilterEnums.Categories.DesignOption:
                    case FilterEnums.Categories.Workset:
                    case FilterEnums.Categories.Type:
                        list.Add("Name");
                        return list;
                    case FilterEnums.Categories.View:
                        list.Add("Name");
                        list.Add("Is Defined");
                        break;
                    case FilterEnums.Categories.Family:
                        list.Add("Name");
                        list.Add("Is In Place");
                        return list;
                    case FilterEnums.Categories.TypeOrInstance:
                        list.Add("Is Element Type");
                        return list;
                    case FilterEnums.Categories.Level:
                        list.Add("Name");
                        list.Add("Elevation");
                        return list;
                    case FilterEnums.Categories.Parameter:
                    case FilterEnums.Categories.HostParameter:
                        //list.AddRange(SharedData.BuiltInParameterValues);
                        return list;
                    case FilterEnums.Categories.PhaseStatus:
                    case FilterEnums.Categories.APIParameter:
                        return list;
                    case FilterEnums.Categories.StructuralType:
                        list.Add("Value");
                        return list;
                    case FilterEnums.Categories.APIType:
                        list.Add("Full Class Name");
                        return list;
                    case FilterEnums.Categories.Redundant:
                        list.Add("Location");
                        list.Add("Type");
                        return list;
                    case FilterEnums.Categories.Host:
                        list.Add("Is Defined");
                        return list;
                }
                return list;
            }
        }

        ///// <summary>
        ///// Currently available options for values
        ///// </summary>
        public List<string> ValueOptions
        {
            get
            {
                List<string> list = new List<string>();
                //if (Category == FilterEnums.Categories.TypeOrInstance || Property == "Is In Place" || Property == "Is Defined" || Condition == FilterEnums.Conditions.Defined || Condition == Enums.Conditions.HasValue || Condition == Enums.Conditions.HasNoValue || Condition == Enums.Conditions.Undefined || Condition == Enums.Conditions.Duplicated || Condition == Enums.Conditions.Included || Category == Enums.Categories.Redundant)
                //{
                //    list.Add("True");
                //    list.Add("False");
                //}
                if (Category == FilterEnums.Categories.PhaseStatus)
                {
                    list.Add("Existing");
                    list.Add("New");
                    list.Add("Demolished");
                    list.Add("Temporary");
                    list.Add("Future");
                }
                //else if (Category == FilterEnums.Categories.StructuralType)
                //{
                //    list.AddRange(SharedData.StructuralTypeValues);
                //}
                //if (Condition == FilterEnums.Conditions.MatchesParameter || Condition == Enums.Conditions.DoesNotMatchParameter)
                //{
                //    list.AddRange(SharedData.BuiltInParameterValues);
                //}
                return list;
            }
        }

        ///// <summary>
        ///// If this filter can move up in the display list
        ///// </summary>
        //public bool CanMoveUp => Check.Filters.IndexOf(this) > 0;

        ///// <summary>
        ///// If this filter can move down in the display list
        ///// </summary>
        //public bool CanMoveDown => Check.Filters.IndexOf(this) < Check.Filters.Count - 1;

        /// <summary>
        /// The unit for this filter
        /// </summary>
        public FilterEnums.Units Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    //OnPropertyChanged("Unit");
                    //OnPropertyChanged("ConvertedValue");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("UnitDisplay");
                }
            }
        }

        /// <summary>
        /// The unit class for this filter
        /// </summary>
        public FilterEnums.UnitClasses UnitClass
        {
            get
            {
                return _unitClass;
            }
            set
            {
                if (_unitClass != value)
                {
                    _unitClass = value;
                    //OnPropertyChanged("UnitClass");
                    //OnPropertyChanged("UnitClassDisplay");
                    //OnPropertyChanged("UnitOptions");
                    //OnPropertyChanged("Unit");
                    //OnPropertyChanged("UnitDisplay");
                    //OnPropertyChanged("AllowUnitSelection");
                    //OnPropertyChanged("ConvertedValue");
                    //OnPropertyChanged("DisplayText");
                    //OnPropertyChanged("AllowCaseInsensitive");
                }
            }
        }

        ///// <summary>
        ///// The display value for units
        ///// </summary>
        //public string UnitDisplay
        //{
        //    get
        //    {
        //        return Enums.GetUnitDisplay(Unit);
        //    }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            return;
        //        }
        //        Enums.Units units = Enum.GetValues(typeof(Enums.Units)).Cast<Enums.Units>().FirstOrDefault((Enums.Units x) => Enums.GetUnitDisplay(x) == value);
        //        if (_unit != units)
        //        {
        //            if (_unit == Enums.Units.Default && double.TryParse(Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        //            {
        //                Value = UnitConverter.ConvertToDbUnits(result, units).ToString(CultureInfo.InvariantCulture);
        //            }
        //            Unit = units;
        //            //OnPropertyChanged("UnitDisplay");
        //        }
        //    }
        //}

        ///// <summary>
        ///// The display value for unit class
        ///// </summary>
        //public string UnitClassDisplay
        //{
        //    get
        //    {
        //        return Enums.GetUnitClassDisplay(UnitClass);
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            Enums.UnitClasses unitClasses = Enum.GetValues(typeof(Enums.UnitClasses)).Cast<Enums.UnitClasses>().FirstOrDefault((Enums.UnitClasses x) => Enums.GetUnitClassDisplay(x) == value);
        //            if (unitClasses != _unitClass)
        //            {
        //                UnitClass = unitClasses;
        //                Unit = Enums.Units.Default;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// If unit selection is allowed
        /// </summary>
        public bool AllowUnitSelection => UnitClass != FilterEnums.UnitClasses.None;

        /// <summary>
        /// If unit designators are to be shown
        /// </summary>
        //public bool ShowUnitDesignators
        //{
        //    get
        //    {
        //        if ((Category == FilterEnums.Categories.Parameter || Category == FilterEnums.Categories.HostParameter) && !FieldIsUserDefined)
        //        {
        //            return FilterEnums.IsConditionNumeric(Condition);
        //        }
        //        return false;
        //    }
        //}

        /// <summary>
        /// The currently available options for units
        /// </summary>
        //public List<string> UnitOptions => UnitConverter.GetValidUnits(_unitClass).Select(Enums.GetUnitDisplay).ToList();

        /// <summary>
        /// The UI indent level of this filter
        /// </summary>
        //public int IndentLevel
        //{
        //    get
        //    {
        //        return _indentLevel;
        //    }
        //    set
        //    {
        //        if (_indentLevel != value)
        //        {
        //            _indentLevel = value;
        //            //OnPropertyChanged("IndentLevel");
        //        }
        //    }
        //}

        ///// <summary>
        ///// Class Constructor
        ///// </summary>
        ///// <param name="ck">The Check that this filter applies to.</param>
        ///// <param name="idOverride">If passed, the ID of the filter will be set to the passed value.  This should be used for deserializing filters.</param>
        //public Filter(Check ck, string idOverride = "")
        //{
        //    _check = ck ?? throw new ArgumentNullException("ck");
        //    if (PropertyOptions.Count > 0)
        //    {
        //        Property = PropertyOptions[0];
        //    }
        //    if (ValueOptions.Count > 0)
        //    {
        //        Value = ValueOptions[0];
        //    }
        //    Id = (string.IsNullOrEmpty(idOverride) ? Guid.NewGuid() : new Guid(idOverride));
        //}

        ///// <summary>
        ///// Create a duplicate of this filter that is a separate object but has the same values
        ///// </summary>
        ///// <returns></returns>
        //public Filter Clone(bool newId = true)
        //{
        //    return new Filter(Check, newId ? string.Empty : Id.ToString())
        //    {
        //        Category = Category,
        //        Condition = Condition,
        //        FieldIsUserDefined = FieldIsUserDefined,
        //        FieldTitle = FieldTitle,
        //        Operator = Operator,
        //        Property = Property,
        //        Validation = Validation,
        //        Value = Value,
        //        UnitClass = UnitClass,
        //        Unit = Unit,
        //        CaseInsensitive = CaseInsensitive
        //    };
        //}

        internal void NotifyOrderChanged()
        {
            //OnPropertyChanged("CanMoveUp");
            //OnPropertyChanged("CanMoveDown");
        }
    }
}
