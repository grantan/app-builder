using AppBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBuilder.DAL
{
	public class ThingPropertyDataAccess
	{
		//private SqlConnection connection = null;
		private SqlConnection connection = null;
		private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["AppBuilderConnectionString"].ToString();
		DataAccess _da;
		string _procName;

		public ThingProperty GetThingProperty(int id)
		{
			_da = new DataAccess();
			_procName = "GetThingProperty";
			SqlParameter[] pars = new SqlParameter[1];  //GetSqlParametersFromObject()
														//= new SqlParam[size_of_type_attribute_list-1]
			pars[0] = new SqlParameter("@id", id);
			ThingPropertyDTO thingPropertyDTO = _da.GetObjectByParameters<ThingPropertyDTO>(constr, _procName, pars);
			ThingProperty thingProperty = new ThingProperty();
			thingProperty.ThingPropertyId = thingPropertyDTO.ThingPropertyId;
			thingProperty.PropertyName = thingPropertyDTO.PropertyName;
			thingProperty.PropertyDescription = thingPropertyDTO.PropertyDescription;

			ThingDataAccess tda = new ThingDataAccess();
			Thing ownedThing = tda.GetThingByID(thingPropertyDTO.OwnedThingId);
			thingProperty.OwnedThing = ownedThing;

			return thingProperty;			
		}

		public Thing GetOwnerByThingPropertyId(int thingPropertyId)
		{			
			_da = new DataAccess();
			_procName = "GetOwnerByThingPropertyId";
			SqlParameter[] pars = new SqlParameter[1];  //GetSqlParametersFromObject()
														//= new SqlParam[size_of_type_attribute_list-1]
			pars[0] = new SqlParameter("@ThingPropertyId", thingPropertyId);
			Thing Thing = _da.GetObjectByParameters<Thing>(constr, _procName, pars);
			return Thing;					
		}

		public void UpdateThingProperty(ThingProperty thingProperty)
		{
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand("UpdateThingProperty", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@thingPropertyId", thingProperty.ThingPropertyId);
				command.Parameters.AddWithValue("@propertyId", thingProperty.OwnedThing.Id);
				command.Parameters.AddWithValue("@name", thingProperty.PropertyName);
				command.Parameters.AddWithValue("@description", thingProperty.PropertyDescription);
				command.Parameters.AddWithValue("@isList", thingProperty.IsList);

				//try to open the connection
				try
				{
					connection.Open();
				}
				catch (Exception ex)
				{
					//There is a problem connecting to the instance of the SQL Server.  
					//For example, the connection string might be wrong,  
					//or the SQL Server might not be available to you. 
					string error = ex.GetBaseException().ToString();
				}

				//Execute the query.  
				try
				{
					int rowsAffected = Int32.Parse(command.ExecuteNonQuery().ToString());

				}
				catch (Exception ex)
				{
					//There was a problem executing the query. For examaple, your SQL statement  
					//might be wrong, or you might not have permission to create records in the  
					//specified table. 
					string error = ex.ToString();
				}

				//is this necessary?
				finally
				{
					connection.Close();
				}
			}
		}

		public void DeleteThingProperty(int id)
		{
			_da = new DataAccess();
			_procName = "DeleteThingProperty";
			SqlParameter[] pars = new SqlParameter[1];  //GetSqlParametersFromObject()
														//= new SqlParam[size_of_type_attribute_list-1]
			pars[0] = new SqlParameter("@thingPropertyId", id);
			int rowsAffected =_da.UpdateDeleteObject(constr, _procName, pars);
		}

		public void InsertThingProperty(int ownerThingId, int propertyThingId, string name, string description, bool isList)
		{
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand("AddThingProperty", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@ownerId", ownerThingId);
				command.Parameters.AddWithValue("@propertyId", propertyThingId);
				command.Parameters.AddWithValue("@name", name);
				command.Parameters.AddWithValue("@description", description);
				command.Parameters.AddWithValue("@isList", isList);

				//try to open the connection
				try
				{
					connection.Open();
				}
				catch (Exception ex)
				{
					//There is a problem connecting to the instance of the SQL Server.  
					//For example, the connection string might be wrong,  
					//or the SQL Server might not be available to you. 
					string error = ex.GetBaseException().ToString();
				}

				//Execute the query.  
				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					//There was a problem executing the query. For examaple, your SQL statement  
					//might be wrong, or you might not have permission to create records in the  
					//specified table. 
					string error = ex.ToString();
				}

				//is this necessary?
				finally
				{
					connection.Close();
				}
			}

		}

		public List<ThingProperty> GetThingProperties(int ownerThingId)
		{
			List<ThingProperty> returnList = new List<ThingProperty>();
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand("GetOwnerPropertyList", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@ownerId", ownerThingId);

				//try to open the connection
				try
				{
					connection.Open();
				}
				catch (Exception ex)
				{
					//There is a problem connecting to the instance of the SQL Server.  
					//For example, the connection string might be wrong,  
					//or the SQL Server might not be available to you. 
					string error = ex.GetBaseException().ToString();
				}

				//Execute the query.  
				try
				{
					// Use the Command object to create a data reader
					SqlDataReader dataReader = command.ExecuteReader();

					// Read the data reader's rows into the PropertyList
					if (dataReader.HasRows)
					{
						while (dataReader.Read())
						{
							ThingProperty thingProperty = new ThingProperty();
							thingProperty.ThingPropertyId = dataReader.GetInt32(0);
							thingProperty.PropertyName = dataReader.GetString(1);
							thingProperty.PropertyDescription = dataReader.GetString(2);
							thingProperty.IsList = dataReader.GetBoolean(3);

							//Thing ownerThing = new Thing();
							//ownerThing.Id = dataReader.GetInt32(3);
							//ownerThing.Name = dataReader.GetString(4);
							//ownerThing.Description = dataReader.GetString(5);

							Thing ownedThing = new Thing();
							////ownedThing.Id = dataReader.GetInt32(6);
							ownedThing.Name = dataReader.GetString(4);
							//ownedThing.Description = dataReader.GetString(8);
							thingProperty.OwnedThing = ownedThing;
							// Add it to the thingList
							returnList.Add(thingProperty);

							//clsProperty Property = new clsProperty();
							//Property.PropertyID = dataReader.GetInt32(0);
							//Property.PropertyName = dataReader.GetString(1);
							//Property.PropertyValue = dataReader.GetString(2);
							//Property.PropertyParentID = dataReader.GetInt32(3);
							//Property.PropertyParentName = dataReader.GetString(4);
							//Property.FieldID = dataReader.GetInt32(5);
							//Property.IsActive = dataReader.GetBoolean(6);
							//// Add it to the Property list
							//Properties.Add(Property);
						}
					}
				}
				catch (Exception ex)
				{
					//There was a problem executing the query. For examaple, your SQL statement  
					//might be wrong, or you might not have permission to create records in the  
					//specified table. 
					string error = ex.ToString();
				}

				//is this necessary?
				finally
				{
					connection.Close();
				}
			}
			return returnList;
		}

	}
}