using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using BeeHive.L30.Domain.SL30.Base;
using BeeHive.L90.Generics.SL10;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeHive.L30.Domain.SL11.Repository.Common
{
    public class UserRolesRepository : RepositoryBase<UserRoles>, IUserRolesRepository
    {
       public List<UserRoles> GetByUserId(long userId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = @$"SELECT id Id, hopper_id UserId, role_id RoleID  FROM public.beehive_user_role where hopper_id={userId}";
                List<UserRoles> menuLookup = conn.Query<UserRoles>(query).ToList();
                conn.Close();
                conn.Dispose();
                return menuLookup;
            }
            catch (NpgsqlException ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Tracer.Instance.TraceException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
