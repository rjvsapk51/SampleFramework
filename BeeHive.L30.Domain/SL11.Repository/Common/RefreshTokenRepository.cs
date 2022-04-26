using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using BeeHive.L30.Domain.SL30.Base;
using BeeHive.L90.Generics.SL10;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeeHive.L30.Domain.SL11.Repository.Common
{
    public class RefreshTokenRepository : RepositoryBase<RefreshTokens>, IRefreshTokenRepository
    {
        public RefreshTokens GetByRefreshToken(string token)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = @$"select id as Id,hopper_id as HopperId,refresh_token as RefreshToken from refresh_token
                where refresh_token = '{token}'";
                List<RefreshTokens> user = conn.Query<RefreshTokens>(query).ToList();
                if (user.Count == 0) return null;
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
