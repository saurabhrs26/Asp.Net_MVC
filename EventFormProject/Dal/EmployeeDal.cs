using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using EventFormProject.Models;
using MySql.Data.MySqlClient;

namespace EventFormProject.Dal
{
    public class EmployeeDal
    {
        public List<Employee> GetAllEmployee()
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["EvrntFormConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "GetAllEmployee";
                    MySqlDataReader DR = CMD.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while (DR.Read())
                    {
                        employees.Add(new Employee()
                        {
                            EmployeeId = Convert.ToInt32(DR["empId"]),
                            EmployeeName = Convert.ToString(DR["empName"]),
                            EmployeeAddress = Convert.ToString(DR["address"]),
                            EmployeeCity = Convert.ToString(DR["city"]),
                            EmployeeCountry = Convert.ToString(DR["country"]),
                            EmployeePhone = Convert.ToInt32(DR["phone"]),
                            EmployeeMail = Convert.ToString(DR["email"]),
                            EmployeeSkill = Convert.ToString(DR["skillsets"]),
                            EmployeeAvtar = Convert.ToString(DR["avatar"]),
                            EmployeeZipcode = Convert.ToInt32(DR["zipcode"])

                        });
                    }
                    DR.Close();
                    CN.Close();
                    return employees;
                }
            }
        }
        public Employee GetEmployeeById(int id)
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["EvrntFormConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "GetEmployeeById";
                    CMD.Parameters.AddWithValue("p_id", id);
                    MySqlDataReader DR = CMD.ExecuteReader();
                    DR.Read();
                    Employee employee = new Employee()
                    {
                        EmployeeId = Convert.ToInt32(DR["empId"]),
                        EmployeeName = Convert.ToString(DR["empName"]),
                        EmployeeAddress = Convert.ToString(DR["address"]),
                        EmployeeCity = Convert.ToString(DR["city"]),
                        EmployeeCountry = Convert.ToString(DR["country"]),
                        EmployeePhone = Convert.ToInt32(DR["phone"]),
                        EmployeeMail = Convert.ToString(DR["email"]),
                        EmployeeSkill = Convert.ToString(DR["skillsets"]),
                        EmployeeAvtar = Convert.ToString(DR["avatar"]),
                        EmployeeZipcode = Convert.ToInt32(DR["zipcode"])
                    };
                    DR.Close();
                    CN.Close();
                    return employee;

                }
            }
        }
        public int InsertEmployee(Employee employee)
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["SynechronEventsConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("p_name", employee.EmployeeName);
                    CMD.Parameters.AddWithValue("p_address", employee.EmployeeAddress);
                    CMD.Parameters.AddWithValue("p_city", employee.EmployeeCity);
                    CMD.Parameters.AddWithValue("p_country", employee.EmployeeCountry);
                    CMD.Parameters.AddWithValue("p_phn", employee.EmployeePhone);
                    CMD.Parameters.AddWithValue("p_email", employee.EmployeeMail);
                    CMD.Parameters.AddWithValue("p_skillsets", employee.EmployeeSkill);
                    CMD.Parameters.AddWithValue("p_avatar", employee.EmployeeAvtar);
                    CMD.Parameters.AddWithValue("p_zipcde", employee.EmployeeZipcode);
                    int result = CMD.ExecuteNonQuery();
                    CN.Close();
                    return result;


                }
            }
            

        }

    }
}