using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace NET.App.Revit.Extensions
{

    internal class ElementComparerLocation : IEqualityComparer<Element>
    {
        public bool Equals(Element x, Element y)
        {
            //IL_0180: Unknown result type (might be due to invalid IL or missing references)
            //IL_0187: Invalid comparison between Unknown and I4
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if ((x is Room && y is Room) || (x is Space && y is Space))
            {
                return CheckRoom(x, y);
            }
            if (x is Room || y is Room || x is Space || y is Space)
            {
                return false;
            }
            if (x.Location == null || y.Location == null || x.ViewSpecific != y.ViewSpecific)
            {
                return false;
            }
            Category category = x.Category;
            long? num = ((category != null) ? new long?(category.Id.GetIdNumericValue()) : ((long?)null));
            Category category2 = y.Category;
            if (num != ((category2 != null) ? new long?(category2.Id.GetIdNumericValue()) : ((long?)null)))
            {
                return false;
            }
            if (x.GetTypeId()?.GetIdNumericValue() != y.GetTypeId().GetIdNumericValue())
            {
                return false;
            }
            Location location = x.Location;
            LocationCurve val = (LocationCurve)(object)((location is LocationCurve) ? location : null);
            if (val != null)
            {
                Location location2 = y.Location;
                LocationCurve val2 = (LocationCurve)(object)((location2 is LocationCurve) ? location2 : null);
                if (val2 != null)
                {
                    if (Math.Abs(val.Curve.Length - val2.Curve.Length) < 0.01 && (int)val.Curve.Intersect(val2.Curve) == 64)
                    {
                        return true;
                    }
                    goto IL_01b7;
                }
            }
            if (x.Location is LocationPoint && y.Location is LocationPoint)
            {
                return GetLocationHash(x) == GetLocationHash(y);
            }
            goto IL_01b7;
        IL_01b7:
            return false;
        }

        public int GetHashCode(Element obj)
        {
            return (int)obj.Id.GetIdNumericValue();
        }

        public static bool CheckRoom(Element rmX, Element rmY)
        {
            //IL_0051: Unknown result type (might be due to invalid IL or missing references)
            //IL_0057: Expected O, but got Unknown
            //IL_0058: Unknown result type (might be due to invalid IL or missing references)
            //IL_005e: Expected O, but got Unknown
            //IL_008c: Unknown result type (might be due to invalid IL or missing references)
            //IL_0092: Expected O, but got Unknown
            if (rmX == null)
            {
                throw new ArgumentNullException("rmX");
            }
            if (rmY == null)
            {
                throw new ArgumentNullException("rmY");
            }
            if (rmX.Id.GetIdNumericValue() == rmY.Id.GetIdNumericValue())
            {
                return false;
            }
            if (rmX.LevelId.GetIdNumericValue() != rmY.LevelId.GetIdNumericValue())
            {
                return false;
            }
            SpatialElement val = (SpatialElement)rmX;
            SpatialElement val2 = (SpatialElement)rmY;
            if (Math.Abs(val.Area) > 1E-05 && Math.Abs(val2.Area) > 1E-05)
            {
                return false;
            }
            SpatialElementBoundaryOptions val3 = new SpatialElementBoundaryOptions();
            IList<BoundarySegment> list = val.GetBoundarySegments(val3)[0];
            IList<BoundarySegment> source = val2.GetBoundarySegments(val3)[0];
            foreach (BoundarySegment segA in list)
            {
                if (!source.Any((BoundarySegment segB) => (int)segA.GetCurve().Intersect(segB.GetCurve()) == 64))
                {
                    return false;
                }
            }
            return true;
        }

        [Localizable(false)]
        public static string GetLocationHash(Element e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (e is Room || e is Space)
            {
                if (e.LevelId.GetIdNumericValue() != ElementId.InvalidElementId.GetIdNumericValue())
                {
                    return e.Category.Id.GetIdStringValue() + e.LevelId.GetIdStringValue();
                }
                return "Skip";
            }
            Location location = e.Location;
            LocationPoint val = (LocationPoint)(object)((location is LocationPoint) ? location : null);
            if (val == null)
            {
                if (location is LocationCurve)
                {
                    return "Curve Based";
                }
                return "Skip";
            }
            Category category = e.Category;
            string text = ((category != null) ? category.Id.GetIdStringValue() : null) ?? string.Empty;
            string obj = (e.ViewSpecific ? e.OwnerViewId.GetIdStringValue() : string.Empty);
            string text2 = ((e.Category != null && (e.Category.Id.GetIdNumericValue() == ((BuiltInCategory)(-2001330)).GetBicNumericValue() || e.Category.Id.GetIdNumericValue() == ((BuiltInCategory)(-2000100)).GetBicNumericValue())) ? e.LevelId.GetIdStringValue() : string.Empty);
            string text3 = obj + text + text2 + e.GetTypeId().GetIdStringValue();
            if (val.Point != null)
            {
                text3 += val.Point.X.ToString(CultureInfo.InvariantCulture);
                text3 += val.Point.Y.ToString(CultureInfo.InvariantCulture);
                text3 += val.Point.Z.ToString(CultureInfo.InvariantCulture);
            }
            if (!(e is Group))
            {
                text3 += val.Rotation.ToString(CultureInfo.InvariantCulture);
            }
            FamilyInstance val2 = (FamilyInstance)(object)((e is FamilyInstance) ? e : null);
            if (val2 == null)
            {
                return text3;
            }
            text3 += (val2.Mirrored ? "1" : "0");
            if (val2.CanFlipFacing)
            {
                text3 += (val2.FacingFlipped ? "1" : "0");
            }
            if (val2.CanFlipHand)
            {
                text3 += (val2.HandFlipped ? "1" : "0");
            }
            if (val2.CanFlipWorkPlane)
            {
                text3 += (val2.IsWorkPlaneFlipped ? "1" : "0");
            }
            return text3;
        }
    }
}
