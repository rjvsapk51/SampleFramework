﻿using BeeHive.L30.Domain.SL10.IRepository.Common;
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
    public class RoleMenuRepository : RepositoryBase<RoleMenu>,IRoleMenuRepository
    {
        public List<RoleMenu> GetByRoleId(long roleId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            try
            {
                string query = @$"SELECT id Id, role_id RoleId, menu_id MenuId FROM public.beehive_role_menu where role_id = {roleId}";
                List<RoleMenu> menuLookup = conn.Query<RoleMenu>(query).ToList();
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
