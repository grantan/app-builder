using AppBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBuilder.DAL
{
	public class ThingDataAccess
	{
		//private SqlConnection connection = null;
		private SqlConnection connection = null;
		private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["AppBuilderConnectionString"].ToString();
		DataAccess _da;
		string _procName;

		public Thing NewThing(Thing thing)
		{
			_da = new DataAccess();
			_procName = "NewThing";
			SqlParameter[] pars = new SqlParameter[2];  //= new SqlParam[size_of_type_attribute_list-1]

			pars[0] = new SqlParameter("@Name", thing.Name);
			pars[1] = new SqlParameter("@Description", thing.Description);
			thing.Id = _da.InsertForIdentity(constr, _procName, pars);
			
			return thing;
		}

		public Thing GetThingByID(int ThingID)
		{
			_da = new DataAccess();
			_procName = "GetThingByID";
			SqlParameter[] pars = new SqlParameter[1];  //GetSqlParametersFromObject()
				  //= new SqlParam[size_of_type_attribute_list-1]
			pars[0] = new SqlParameter("@Id", ThingID);
			Thing Thing = _da.GetObjectByParameters<Thing>(constr, _procName, pars);
			return Thing;
			//connection = new SqlConnection(constr);

			////Tell the SqlCommand what query to execute and what SqlConnection to use.  
			//using (SqlCommand command = new SqlCommand("GetThingByID", connection))  //GetThingsAll
			//{
			//	command.CommandType = CommandType.StoredProcedure;
			//	//Add SqlParameters to the SqlCommand  
			//	command.Parameters.AddWithValue("@Id", ThingID);

			//	//try to open the connection
			//	try
			//	{
			//		connection.Open();
			//	}
			//	catch (Exception ex)
			//	{
			//		//There is a problem connecting to the instance of the SQL Server.  
			//		//For example, the connection string might be wrong,  
			//		//or the SQL Server might not be available to you. 
			//		string error = ex.GetBaseException().ToString();
			//	}

			//	//Execute the query.  
			//	try
			//	{

			//		// Use the Command object to create a data reader
			//		SqlDataReader dataReader = command.ExecuteReader();


			//		// Read the data reader's rows into the PropertyList
			//		if (dataReader.HasRows)
			//		{
			//			while (dataReader.Read())
			//			{
			//				Thing = new Thing();
			//				Thing.Id = dataReader.GetInt32(0);
			//				Thing.Name = dataReader.GetString(1);
			//				Thing.Description = dataReader.GetString(2);
			//				//Thing.ThingConnectionString = dataReader.GetString(3);
			//				//Thing.IsActive = dataReader.GetBoolean(4);

			//			}
			//		}

			//	}
			//	catch (Exception ex)
			//	{
			//		//There was a problem executing the query. For examaple, your SQL statement  
			//		//might be wrong, or you might not have permission to create records in the  
			//		//specified table. 
			//		string error = ex.ToString();
			//	}

			//}


		}

		public List<Thing> GetThingList()
		{
			_da = new DataAccess();
			_procName = "AllThings";
			//SqlParameter[] pars = new SqlParameter[1];  //GetSqlParametersFromObject()
														//= new SqlParam[size_of_type_attribute_list-1]
			//pars[0] = new SqlParameter("@Id", ThingID);
			//Thing Thing = _da.GetObjectByParameters<Thing>(constr, _procName, pars);
			List<Thing> things = _da.GetObjectList<Thing>(constr, _procName);
			return things;

			//connection = new SqlConnection(constr);

			////Tell the SqlCommand what query to execute and what SqlConnection to use.  
			//using (SqlCommand command = new SqlCommand("AllThings", connection))  //
			//{
			//	command.CommandType = CommandType.StoredProcedure;

			//	//try to open the connection
			//	try
			//	{
			//		connection.Open();
			//	}
			//	catch (Exception ex)
			//	{
			//		//There is a problem connecting to the instance of the SQL Server.  
			//		//For example, the connection string might be wrong,  
			//		//or the SQL Server might not be available to you. 
			//		string error = ex.GetBaseException().ToString();
			//	}

			//	//Execute the query.  
			//	try
			//	{
			//		// Use the Command object to create a data reader
			//		SqlDataReader dataReader = command.ExecuteReader();

			//		// Read the data reader's rows into the PropertyList
			//		if (dataReader.HasRows)
			//		{
			//			while (dataReader.Read())
			//			{
			//				Thing thing = new Thing();
			//				thing.Id = dataReader.GetInt32(0);
			//				thing.Name = dataReader.GetString(1);
			//				thing.Description = dataReader.GetString(2);
			//				// Add it to the thingList
			//				things.Add(thing);

			//				//clsProperty Property = new clsProperty();
			//				//Property.PropertyID = dataReader.GetInt32(0);
			//				//Property.PropertyName = dataReader.GetString(1);
			//				//Property.PropertyValue = dataReader.GetString(2);
			//				//Property.PropertyParentID = dataReader.GetInt32(3);
			//				//Property.PropertyParentName = dataReader.GetString(4);
			//				//Property.FieldID = dataReader.GetInt32(5);
			//				//Property.IsActive = dataReader.GetBoolean(6);
			//				//// Add it to the Property list
			//				//Properties.Add(Property);
			//			}
			//		}


			//	}
			//	catch (Exception ex)
			//	{
			//		//There was a problem executing the query. For examaple, your SQL statement  
			//		//might be wrong, or you might not have permission to create records in the  
			//		//specified table. 
			//		string error = ex.ToString();
			//	}

			//}
			//return things;
		}

		public void EditThing(Thing Thing)
		{
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand("UpdateThing", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@Id", Thing.Id);
				command.Parameters.AddWithValue("@Name", Thing.Name);
				command.Parameters.AddWithValue("@Description", Thing.Description);
				//command.Parameters.AddWithValue("@ThingConnectionString", Thing.ThingConnectionString);
				//command.Parameters.AddWithValue("@IsActive", Thing.IsActive);

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

		public ThingProperty GetThingProperty(int id)
		{
			ThingProperty thingProperty = new ThingProperty();

			connection = new SqlConnection(constr);

			//Tell the SqlCommand what query to execute and what SqlConnection to use.  
			using (SqlCommand command = new SqlCommand("GetThingProperty", connection))  //GetThingsAll
			{
				command.CommandType = CommandType.StoredProcedure;
				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@id", id);

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
							thingProperty.ThingPropertyId = dataReader.GetInt32(0);
							thingProperty.PropertyName = dataReader.GetString(1);
							thingProperty.PropertyDescription = dataReader.GetString(2);
							thingProperty.IsList = dataReader.GetBoolean(3);

							Thing ownerThing = new Thing();
							ownerThing.Id = dataReader.GetInt32(4);
							ownerThing.Name = dataReader.GetString(5);
							ownerThing.Description = dataReader.GetString(6);
							thingProperty.OwnerThing = ownerThing;

							Thing ownedThing = new Thing();
							ownedThing.Id = dataReader.GetInt32(7);
							ownedThing.Name = dataReader.GetString(8);
							ownedThing.Description = dataReader.GetString(9);
							thingProperty.OwnedThing = ownedThing;

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

			}
			return thingProperty;

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

		

		public void SaveThingInheritance(int thingTypeID, int thingID)
		{
			connection = new SqlConnection(constr);

			//Tell the SqlCommand what query to execute and what SqlConnection to use.  
			using (SqlCommand command = new SqlCommand("AddThingInheritance", connection))  //
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@parentId", thingTypeID);
				command.Parameters.AddWithValue("@childId", thingID);

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

			}
			
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

		/// <summary>
		/// ?needed
		/// </summary>
		/// <param name="Thing"></param>
		public void DisableThing(Thing Thing)
		{
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand("DisableThing", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				//Add SqlParameters to the SqlCommand  
				command.Parameters.AddWithValue("@ID", Thing.Id);

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
	}
}