﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AppBuilder.DAL
{
	public class DataAccess
	{
		private SqlConnection connection = null;
		//private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["AppBuilderConnectionString"].ToString();

		public int InsertForIdentity(string constr, string storedProcedureName, SqlParameter[] parameters = null )
		{
			int scalarVal = 0;
			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				if (parameters != null && parameters.Length > 0)
				{
					foreach(SqlParameter param in parameters)
					{
						command.Parameters.AddWithValue(param.ParameterName, param.Value);
					}
				}
				
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
					scalarVal = Int32.Parse(command.ExecuteScalar().ToString());
				}
				catch (Exception ex)
				{
					//There was a problem executing the query. For examaple, your SQL statement  
					//might be wrong, or you might not have permission to create records in the  
					//specified table. 
					string error = ex.ToString();
				}

			}

			return scalarVal;
		}

		//public T GetObjectById<T>
		public T GetObjectByParameters<T>(string constr, string storedProcedureName, SqlParameter[] pars)    //SqlParameter[] parameters = null
		{

			//Type typeArgument = Type.GetType(T);
			Type template = typeof(T);
			//Type genericType = template.MakeGenericType();
			object instance = Activator.CreateInstance(template);
			PropertyInfo[] props = typeof(T).GetProperties();

			connection = new SqlConnection(constr);

			using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				if (pars != null && pars.Length > 0)
				{
					foreach (SqlParameter param in pars)
					{
						command.Parameters.AddWithValue(param.ParameterName, param.Value);
					}
				}

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
							int columnNumber = 0;
							//Type t = instance.GetType();
							foreach (var propInfo in props)
							{
								Type type = propInfo.GetType();
								var value = dataReader.GetValue(columnNumber++);
								propInfo.SetValue(instance, value, null);
							}
							//Thing = new Thing();
							//Thing.Id = dataReader.GetInt32(0);
							//Thing.Name = dataReader.GetString(1);
							//Thing.Description = dataReader.GetString(2);
							//Thing.ThingConnectionString = dataReader.GetString(3);
							//Thing.IsActive = dataReader.GetBoolean(4);

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

			return (T) instance;
		}

			//	return _dict;

			//	connection = new SqlConnection(constr);

			//	//Tell the SqlCommand what query to execute and what SqlConnection to use.  
			//	using (SqlCommand command = new SqlCommand("GetThingByID", connection))  //GetThingsAll
			//	{
			//		command.CommandType = CommandType.StoredProcedure;
			//		//Add SqlParameters to the SqlCommand  
			//		command.Parameters.AddWithValue("@Id", ThingID);

			//		//try to open the connection
			//		try
			//		{
			//			connection.Open();
			//		}
			//		catch (Exception ex)
			//		{
			//			//There is a problem connecting to the instance of the SQL Server.  
			//			//For example, the connection string might be wrong,  
			//			//or the SQL Server might not be available to you. 
			//			string error = ex.GetBaseException().ToString();
			//		}

			//		//Execute the query.  
			//		try
			//		{

			//			// Use the Command object to create a data reader
			//			SqlDataReader dataReader = command.ExecuteReader();


			//			// Read the data reader's rows into the PropertyList
			//			if (dataReader.HasRows)
			//			{
			//				while (dataReader.Read())
			//				{
			//					Thing = new Thing();
			//					Thing.Id = dataReader.GetInt32(0);
			//					Thing.Name = dataReader.GetString(1);
			//					Thing.Description = dataReader.GetString(2);
			//					//Thing.ThingConnectionString = dataReader.GetString(3);
			//					//Thing.IsActive = dataReader.GetBoolean(4);

			//				}
			//			}

			//		}
			//		catch (Exception ex)
			//		{
			//			//There was a problem executing the query. For examaple, your SQL statement  
			//			//might be wrong, or you might not have permission to create records in the  
			//			//specified table. 
			//			string error = ex.ToString();
			//		}

			//	}
			//	return Thing;

			//}

			//public List<Thing> GetThingList()
			//{
			//	List<Thing> things = new List<Thing>();

			//	connection = new SqlConnection(constr);

			//	//Tell the SqlCommand what query to execute and what SqlConnection to use.  
			//	using (SqlCommand command = new SqlCommand("AllThings", connection))  //
			//	{
			//		command.CommandType = CommandType.StoredProcedure;

			//		//try to open the connection
			//		try
			//		{
			//			connection.Open();
			//		}
			//		catch (Exception ex)
			//		{
			//			//There is a problem connecting to the instance of the SQL Server.  
			//			//For example, the connection string might be wrong,  
			//			//or the SQL Server might not be available to you. 
			//			string error = ex.GetBaseException().ToString();
			//		}

			//		//Execute the query.  
			//		try
			//		{
			//			// Use the Command object to create a data reader
			//			SqlDataReader dataReader = command.ExecuteReader();

			//			// Read the data reader's rows into the PropertyList
			//			if (dataReader.HasRows)
			//			{
			//				while (dataReader.Read())
			//				{
			//					Thing thing = new Thing();
			//					thing.Id = dataReader.GetInt32(0);
			//					thing.Name = dataReader.GetString(1);
			//					thing.Description = dataReader.GetString(2);
			//					// Add it to the thingList
			//					things.Add(thing);

			//					//clsProperty Property = new clsProperty();
			//					//Property.PropertyID = dataReader.GetInt32(0);
			//					//Property.PropertyName = dataReader.GetString(1);
			//					//Property.PropertyValue = dataReader.GetString(2);
			//					//Property.PropertyParentID = dataReader.GetInt32(3);
			//					//Property.PropertyParentName = dataReader.GetString(4);
			//					//Property.FieldID = dataReader.GetInt32(5);
			//					//Property.IsActive = dataReader.GetBoolean(6);
			//					//// Add it to the Property list
			//					//Properties.Add(Property);
			//				}
			//			}


			//		}
			//		catch (Exception ex)
			//		{
			//			//There was a problem executing the query. For examaple, your SQL statement  
			//			//might be wrong, or you might not have permission to create records in the  
			//			//specified table. 
			//			string error = ex.ToString();
			//		}

			//	}
			//	return things;
			//}
		}
}