using BeeHive.L30.Domain.SL10.IRepository;
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
    public class UserRepository: RepositoryBase<Hopper>, IUserRepository
    {
        public Hopper GetUserByUserNameAndPassword(string username,string Password)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = @$"SELECT id Id, identity as Identity, token Token, individual_id IndividualId,is_super_hopper IsSuperHopper,is_blocked IsBlocked, 
                                           last_hopped LastHopped,created_on CreatedOn,created_by CreatedBy,updated_on UpdatedOn,updated_by UpdatedBy 
                                            FROM public.hopper where identity ='{username}' and token = '{Password}'";
                List<Hopper> user = conn.Query<Hopper>(query).ToList();
                if(user.Count == 0) return null;              
                conn.Close();
                conn.Dispose();
                return user.FirstOrDefault();
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
