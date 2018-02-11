﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using PsychologicalServices.Data;
using PsychologicalServices.Data.HelperClasses;
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.FactoryClasses
{
	/// <summary>Generates IEntityFields2 instances for different kind of Entities.</summary>
	public static partial class EntityFieldsFactory
	{
		private static readonly Dictionary<PsychologicalServices.Data.EntityType, string> _entityTypeNamesCache = new Dictionary<PsychologicalServices.Data.EntityType, string>();

		/// <summary>static ctor which initializes the static entity type cache.</summary>
		static EntityFieldsFactory()
		{
			foreach(PsychologicalServices.Data.EntityType value in Enum.GetValues(typeof(PsychologicalServices.Data.EntityType)))
			{
				_entityTypeNamesCache.Add(value, Enum.GetName(typeof(PsychologicalServices.Data.EntityType), value));
			}
		}	

		/// <summary>General factory entrance method which will return an EntityFields2 object with the format generated by the factory specified</summary>
		/// <param name="relatedEntityType">The type of entity the fields are for</param>
		/// <returns>The IEntityFields instance requested</returns>
		public static IEntityFields2 CreateEntityFieldsObject(PsychologicalServices.Data.EntityType relatedEntityType)
		{
			return FieldInfoProviderSingleton.GetInstance().GetEntityFields(InheritanceInfoProviderSingleton.GetInstance(), _entityTypeNamesCache[relatedEntityType]);
		}
		
		/// <summary>General method which will return an array of IEntityFieldCore objects, used by the InheritanceInfoProvider. Only the fields defined in the entity are returned, no inherited fields.</summary>
		/// <param name="entityName">the name of the entity to get the fields for. Example: "CustomerEntity"</param>
		/// <returns>array of IEntityFieldCore fields, defined in the entity with the name specified</returns>
		internal static IEntityFieldCore[] CreateFields(string entityName)
		{
			return FieldInfoProviderSingleton.GetInstance().GetEntityFieldsArray(entityName);
		}


		#region Included Code

		#endregion
	}
}
