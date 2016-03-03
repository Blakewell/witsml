﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Energistics.Datatypes;
using PDS.Framework;
using System.Reflection;
using System.Linq;
using System.Collections;
using Energistics.DataAccess.WITSML141.ReferenceData;
using Energistics.DataAccess.WITSML141.ComponentSchemas;
using Energistics.DataAccess;

namespace PDS.Witsml.Server.Data
{
    /// <summary>
    /// Data adapter that encapsulates CRUD functionalities on WITSML objects.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <seealso cref="PDS.Witsml.Server.Data.IWitsmlDataAdapter{T}" />
    /// <seealso cref="PDS.Witsml.Server.Data.IEtpDataAdapter{T}" />
    public abstract class WitsmlDataAdapter<T> : IWitsmlDataAdapter<T>, IEtpDataAdapter<T>
    {
        /// <summary>
        /// Gets or sets the composition container.
        /// </summary>
        /// <value>The composition container.</value>
        [Import]
        public IContainer Container { get; set; }

        /// <summary>
        /// Queries the object(s) specified by the parser.
        /// </summary>
        /// <param name="parser">The parser that specifies the query parameters.</param>
        /// <returns>
        /// Queried objects.
        /// </returns>
        public virtual WitsmlResult<IEnergisticsCollection> Query(WitsmlQueryParser parser)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an object to the data store.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns>
        /// A WITSML result that includes a positive value indicates a success or a negative value indicates an error.
        /// </returns>
        public virtual WitsmlResult Add(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns>
        /// A WITSML result that includes a positive value indicates a success or a negative value indicates an error.
        /// </returns>
        public virtual WitsmlResult Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes or partially updates the specified object by uid.
        /// </summary>
        /// <param name="parser">The parser that specifies the object.</param>
        /// <returns>
        /// A WITSML result that includes a positive value indicates a success or a negative value indicates an error.
        /// </returns>
        public virtual WitsmlResult Delete(WitsmlQueryParser parser)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the entity exists in the data store.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns>true if the entity exists; otherwise, false</returns>
        public virtual bool Exists(string uid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a collection of data objects related to the specified URI.
        /// </summary>
        /// <param name="parentUri">The parent URI.</param>
        /// <returns>A collection of data objects.</returns>
        public virtual List<T> GetAll(EtpUri? parentUri = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a data object by the specified UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>The data object instance.</returns>
        public virtual T Get(string uuid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Puts the specified data object into the data store.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A WITSML result.</returns>
        public virtual WitsmlResult Put(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a data object by the specified UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>A WITSML result.</returns>
        public virtual WitsmlResult Delete(string uuid)
        {
            throw new NotImplementedException();
        }

        protected void FillObjectTemplateValues(Type objectType, object dataObject)
        {
            PropertyInfo[] propertyInfo = objectType.GetProperties();
            foreach (PropertyInfo property in propertyInfo)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    Type type = propertyType.GetGenericArguments()[0];
                    FillObjectTypeValues(dataObject, objectType, property, type);
                }
                else if (property.Name.ToLower().Equals("TimeZone".ToLower()))
                    property.SetValue(dataObject, "Z");
                else if (property.Name.ToLower().Equals("Date".ToLower()))
                    property.SetValue(dataObject, "1900-01-01");
                else if (property.Name.ToLower().Equals("CalendarYear".ToLower()))
                    property.SetValue(dataObject, "1000");
                else if (property.Name.ToLower().Equals("iadcBearingWearCode".ToLower()))
                    property.SetValue(dataObject, "E");
                else if (property.Name.ToLower().Equals("geodeticZoneString".ToLower()))
                    property.SetValue(dataObject, "60N");
                else if (property.Name.ToLower().Equals("sectionNumber".ToLower()))
                    property.SetValue(dataObject, "36");
                else if (property.Name.ToLower().Equals("publicLandSurveySystemQuarterTownship".ToLower()))
                    property.SetValue(dataObject, "NE");
                else if (property.Name.ToLower().Equals("publicLandSurveySystemQuarterSection".ToLower()))
                    property.SetValue(dataObject, "NE");
                else if (property.Name.ToLower().Equals("number".ToLower()))
                    property.SetValue(dataObject, 1);
                else
                    FillObjectTypeValues(dataObject, objectType, property, property.PropertyType);
            }
        }

        private bool IsIList(Type type)
        {
            bool isIList = type.GetInterfaces()
                           .Any(t => t == typeof(IList));
            return isIList;
        }

        private void FillObjectTypeValues(object dataObject, Type objectType, PropertyInfo property, Type propertyType)
        {
            if (propertyType == typeof(string))
                property.SetValue(dataObject, "abc");
            else if (propertyType == typeof(bool))
            {
                int index = property.Name.LastIndexOf("Specified");
                if (index < 0)
                    property.SetValue(dataObject, false);
                else
                {
                    string specifiedNameSubstring = property.Name.Substring(index, property.Name.Length - index);
                    bool isSpecifiedProperty = specifiedNameSubstring.Equals("Specified");
                    if (!isSpecifiedProperty)
                        property.SetValue(dataObject, false);
                }
            }
            else if (propertyType == typeof(Energistics.Datatypes.DateTime))
                property.SetValue(dataObject, Convert.ToDateTime("1900-01-01T00:00:00.000Z"));
            else if (propertyType == typeof(WellStatus))
                property.SetValue(dataObject, WellStatus.unknown);
            else if (propertyType == typeof(WellPurpose))
                property.SetValue(dataObject, WellPurpose.unknown);
            else if (propertyType == typeof(WellFluid))
                property.SetValue(dataObject, WellFluid.unknown);
            else if (propertyType == typeof(WellDirection))
                property.SetValue(dataObject, WellDirection.unknown);
            else if (propertyType == typeof(LengthUom))
                property.SetValue(dataObject, LengthUom.ft);
            else if (propertyType == typeof(LengthMeasure))
            {
                try
                {
                    property.SetValue(dataObject, new LengthMeasure(1.0, LengthUom.ft));
                }
                catch (Exception)
                { }
            }
            else if (propertyType == typeof(DimensionlessMeasure))
                property.SetValue(dataObject, new DimensionlessMeasure(1.0, DimensionlessUom.Item));
            else if (IsIList(propertyType))
            {
                Type type = propertyType.GetGenericArguments()[0];
                Type[] typeList = new Type[0];
                ConstructorInfo constructorInfo = type.GetConstructor(typeList);
                if (constructorInfo != null)
                {
                    object dObject = Activator.CreateInstance(type);
                    FillObjectTemplateValues(type, dObject);
                    IList dObjectList = Activator.CreateInstance(propertyType) as IList;
                    dObjectList.Add(dObject);
                    property.SetValue(dataObject, dObjectList);
                }
                else if (propertyType == typeof(List<string>))
                    property.SetValue(dataObject, new List<string>() { "abc" });
            }
            else if (propertyType == typeof(CommonData))
            {
                CommonData commonData = new CommonData();
                FillObjectTemplateValues(typeof(CommonData), commonData);
                property.SetValue(dataObject, commonData);
            }
        }
    }
}
