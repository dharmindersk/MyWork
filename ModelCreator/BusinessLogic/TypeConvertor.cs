﻿using System;
using System.Collections;
using System.Data;

namespace BusinessLogic
{
    public class TypeConvertor
    {
        private struct DbTypeMapEntry
        {

            public readonly Type Type;

            public readonly DbType DbType;

            public readonly SqlDbType SqlDbType;

            public DbTypeMapEntry(Type type, DbType dbType, SqlDbType sqlDbType)
            {
                Type = type;
                DbType = dbType;
                SqlDbType = sqlDbType;
            }
        };

        private static ArrayList _DbTypeList = new ArrayList();

        #region Constructors

        static TypeConvertor()
        {
            var dbTypeMapEntry = new DbTypeMapEntry(typeof(bool), DbType.Boolean, SqlDbType.Bit);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(byte), DbType.Double, SqlDbType.TinyInt);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(byte[]), DbType.Binary, SqlDbType.Image);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(DateTime), DbType.DateTime, SqlDbType.DateTime);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Decimal), DbType.Decimal, SqlDbType.Decimal);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(double), DbType.Double, SqlDbType.Float);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Guid), DbType.Guid, SqlDbType.UniqueIdentifier);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int16), DbType.Int16, SqlDbType.SmallInt);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int32), DbType.Int32, SqlDbType.Int);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int64), DbType.Int64, SqlDbType.BigInt);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(object), DbType.Object, SqlDbType.Variant);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(string), DbType.String, SqlDbType.VarChar);

            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(string), DbType.String, SqlDbType.NVarChar);

            _DbTypeList.Add(dbTypeMapEntry);
            dbTypeMapEntry = new DbTypeMapEntry(typeof(DateTime), DbType.Time, SqlDbType.Timestamp);


            _DbTypeList.Add(dbTypeMapEntry);
        }

        private TypeConvertor()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Convert db type to .Net data type
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>

        public static Type ToNetType(DbType dbType)
        {
            var entry = Find(dbType);
            return entry.Type;
        }


        /// <summary>
        /// Convert TSQL type to .Net data type
        /// </summary>
        /// <param name="sqlDbType"></param>
        /// <returns></returns>

        public static Type ToNetType(SqlDbType sqlDbType)
        {
            var entry = Find(sqlDbType);
            return entry.Type;
        }

        /// <summary>
        /// Convert .Net type to Db type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>

        public static DbType ToDbType(Type type)
        {
            var entry = Find(type);
            return entry.DbType;
        }

        /// <summary>
        /// Convert TSQL data type to DbType
        /// </summary>
        /// <param name="sqlDbType"></param>
        /// <returns></returns>

        public static DbType ToDbType(SqlDbType sqlDbType)
        {
            var entry = Find(sqlDbType);
            return entry.DbType;
        }


        /// <summary>
        /// Convert .Net type to TSQL data type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>

        public static SqlDbType ToSqlDbType(Type type)
        {
            var entry = Find(type);
            return entry.SqlDbType;
        }


        /// <summary>
        /// Convert DbType type to TSQL data type
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>

        public static SqlDbType ToSqlDbType(DbType dbType)
        {
            var entry = Find(dbType);
            return entry.SqlDbType;
        }


        private static DbTypeMapEntry Find(Type type)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                var entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.Type == type)
                {
                    retObj = entry;
                    break;
                }
            }

            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported Type");
            }
            return (DbTypeMapEntry)retObj;
        }

        private static DbTypeMapEntry Find(DbType dbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                var entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.DbType == dbType)
                {
                    retObj = entry;
                    break;
                }
            }

            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported DbType");
            }
            return (DbTypeMapEntry)retObj;
        }

        private static DbTypeMapEntry Find(SqlDbType sqlDbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                var entry = (DbTypeMapEntry)_DbTypeList[i];

                if (entry.SqlDbType == sqlDbType)
                {
                    retObj = entry;
                    break;
                }
            }

            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported SqlDbType");
            }
            return (DbTypeMapEntry)retObj;
        }
        #endregion
    }
}