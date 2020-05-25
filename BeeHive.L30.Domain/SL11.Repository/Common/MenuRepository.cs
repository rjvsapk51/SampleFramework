using BeeHive.L30.Domain.SL05.DomainModel.Lookup;
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
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public List<MenuLookup> GetAllMenuLookup()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = @$"select Id,Banner from BEEHIVE_MENU";
                List<MenuLookup> menuLookup = conn.Query<MenuLookup>(query).ToList();
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
