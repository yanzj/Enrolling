﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="zypt_data")]
	public partial class zy_filesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertZY_FILES(ZY_FILES instance);
    partial void UpdateZY_FILES(ZY_FILES instance);
    partial void DeleteZY_FILES(ZY_FILES instance);
    partial void InsertZY_FILES_MAPPING(ZY_FILES_MAPPING instance);
    partial void UpdateZY_FILES_MAPPING(ZY_FILES_MAPPING instance);
    partial void DeleteZY_FILES_MAPPING(ZY_FILES_MAPPING instance);
    #endregion
		
		public zy_filesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["zypt_dataConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public zy_filesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public zy_filesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public zy_filesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public zy_filesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ZY_FILES> ZY_FILES
		{
			get
			{
				return this.GetTable<ZY_FILES>();
			}
		}
		
		public System.Data.Linq.Table<ZY_FILES_MAPPING> ZY_FILES_MAPPING
		{
			get
			{
				return this.GetTable<ZY_FILES_MAPPING>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ZY_FILES")]
	public partial class ZY_FILES : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _guid;
		
		private string _phy_add;
		
		private string _logic_name;
		
		private string _file_type;
		
		private System.Nullable<double> _file_size;
		
		private System.Nullable<System.DateTime> _up_dt;
		
		private System.Nullable<System.DateTime> _cr_dt;
		
		private System.Nullable<System.DateTime> _ed_dt;
		
		private string _md5;
		
		private string _suffix;
		
		private string _up_user;
		
		private string _file_status;
		
		private string _play_add;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnguidChanging(string value);
    partial void OnguidChanged();
    partial void Onphy_addChanging(string value);
    partial void Onphy_addChanged();
    partial void Onlogic_nameChanging(string value);
    partial void Onlogic_nameChanged();
    partial void Onfile_typeChanging(string value);
    partial void Onfile_typeChanged();
    partial void Onfile_sizeChanging(System.Nullable<double> value);
    partial void Onfile_sizeChanged();
    partial void Onup_dtChanging(System.Nullable<System.DateTime> value);
    partial void Onup_dtChanged();
    partial void Oncr_dtChanging(System.Nullable<System.DateTime> value);
    partial void Oncr_dtChanged();
    partial void Oned_dtChanging(System.Nullable<System.DateTime> value);
    partial void Oned_dtChanged();
    partial void Onmd5Changing(string value);
    partial void Onmd5Changed();
    partial void OnsuffixChanging(string value);
    partial void OnsuffixChanged();
    partial void Onup_userChanging(string value);
    partial void Onup_userChanged();
    partial void Onfile_statusChanging(string value);
    partial void Onfile_statusChanged();
    partial void Onplay_addChanging(string value);
    partial void Onplay_addChanged();
    #endregion
		
		public ZY_FILES()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_guid", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string guid
		{
			get
			{
				return this._guid;
			}
			set
			{
				if ((this._guid != value))
				{
					this.OnguidChanging(value);
					this.SendPropertyChanging();
					this._guid = value;
					this.SendPropertyChanged("guid");
					this.OnguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phy_add", DbType="NVarChar(255)")]
		public string phy_add
		{
			get
			{
				return this._phy_add;
			}
			set
			{
				if ((this._phy_add != value))
				{
					this.Onphy_addChanging(value);
					this.SendPropertyChanging();
					this._phy_add = value;
					this.SendPropertyChanged("phy_add");
					this.Onphy_addChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logic_name", DbType="NVarChar(50)")]
		public string logic_name
		{
			get
			{
				return this._logic_name;
			}
			set
			{
				if ((this._logic_name != value))
				{
					this.Onlogic_nameChanging(value);
					this.SendPropertyChanging();
					this._logic_name = value;
					this.SendPropertyChanged("logic_name");
					this.Onlogic_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_type", DbType="NVarChar(50)")]
		public string file_type
		{
			get
			{
				return this._file_type;
			}
			set
			{
				if ((this._file_type != value))
				{
					this.Onfile_typeChanging(value);
					this.SendPropertyChanging();
					this._file_type = value;
					this.SendPropertyChanged("file_type");
					this.Onfile_typeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_size", DbType="Float")]
		public System.Nullable<double> file_size
		{
			get
			{
				return this._file_size;
			}
			set
			{
				if ((this._file_size != value))
				{
					this.Onfile_sizeChanging(value);
					this.SendPropertyChanging();
					this._file_size = value;
					this.SendPropertyChanged("file_size");
					this.Onfile_sizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_up_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> up_dt
		{
			get
			{
				return this._up_dt;
			}
			set
			{
				if ((this._up_dt != value))
				{
					this.Onup_dtChanging(value);
					this.SendPropertyChanging();
					this._up_dt = value;
					this.SendPropertyChanged("up_dt");
					this.Onup_dtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cr_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> cr_dt
		{
			get
			{
				return this._cr_dt;
			}
			set
			{
				if ((this._cr_dt != value))
				{
					this.Oncr_dtChanging(value);
					this.SendPropertyChanging();
					this._cr_dt = value;
					this.SendPropertyChanged("cr_dt");
					this.Oncr_dtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ed_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> ed_dt
		{
			get
			{
				return this._ed_dt;
			}
			set
			{
				if ((this._ed_dt != value))
				{
					this.Oned_dtChanging(value);
					this.SendPropertyChanging();
					this._ed_dt = value;
					this.SendPropertyChanged("ed_dt");
					this.Oned_dtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_md5", DbType="NVarChar(50)")]
		public string md5
		{
			get
			{
				return this._md5;
			}
			set
			{
				if ((this._md5 != value))
				{
					this.Onmd5Changing(value);
					this.SendPropertyChanging();
					this._md5 = value;
					this.SendPropertyChanged("md5");
					this.Onmd5Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_suffix", DbType="NVarChar(10)")]
		public string suffix
		{
			get
			{
				return this._suffix;
			}
			set
			{
				if ((this._suffix != value))
				{
					this.OnsuffixChanging(value);
					this.SendPropertyChanging();
					this._suffix = value;
					this.SendPropertyChanged("suffix");
					this.OnsuffixChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_up_user", DbType="NVarChar(50)")]
		public string up_user
		{
			get
			{
				return this._up_user;
			}
			set
			{
				if ((this._up_user != value))
				{
					this.Onup_userChanging(value);
					this.SendPropertyChanging();
					this._up_user = value;
					this.SendPropertyChanged("up_user");
					this.Onup_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_status", DbType="NVarChar(10)")]
		public string file_status
		{
			get
			{
				return this._file_status;
			}
			set
			{
				if ((this._file_status != value))
				{
					this.Onfile_statusChanging(value);
					this.SendPropertyChanging();
					this._file_status = value;
					this.SendPropertyChanged("file_status");
					this.Onfile_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_play_add", DbType="NVarChar(255)")]
		public string play_add
		{
			get
			{
				return this._play_add;
			}
			set
			{
				if ((this._play_add != value))
				{
					this.Onplay_addChanging(value);
					this.SendPropertyChanging();
					this._play_add = value;
					this.SendPropertyChanged("play_add");
					this.Onplay_addChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ZY_FILES_MAPPING")]
	public partial class ZY_FILES_MAPPING : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _mapping_id;
		
		private string _user_id;
		
		private string _file_guid;
		
		private string _phy_add;
		
		private string _mapping_name;
		
		private string _file_type;
		
		private System.Nullable<double> _file_size;
		
		private System.Nullable<System.DateTime> _map_dt;
		
		private string _first_uploader;
		
		private string _map_status;
		
		private string _play_add;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onmapping_idChanging(string value);
    partial void Onmapping_idChanged();
    partial void Onuser_idChanging(string value);
    partial void Onuser_idChanged();
    partial void Onfile_guidChanging(string value);
    partial void Onfile_guidChanged();
    partial void Onphy_addChanging(string value);
    partial void Onphy_addChanged();
    partial void Onmapping_nameChanging(string value);
    partial void Onmapping_nameChanged();
    partial void Onfile_typeChanging(string value);
    partial void Onfile_typeChanged();
    partial void Onfile_sizeChanging(System.Nullable<double> value);
    partial void Onfile_sizeChanged();
    partial void Onmap_dtChanging(System.Nullable<System.DateTime> value);
    partial void Onmap_dtChanged();
    partial void Onfirst_uploaderChanging(string value);
    partial void Onfirst_uploaderChanged();
    partial void Onmap_statusChanging(string value);
    partial void Onmap_statusChanged();
    partial void Onplay_addChanging(string value);
    partial void Onplay_addChanged();
    #endregion
		
		public ZY_FILES_MAPPING()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mapping_id", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string mapping_id
		{
			get
			{
				return this._mapping_id;
			}
			set
			{
				if ((this._mapping_id != value))
				{
					this.Onmapping_idChanging(value);
					this.SendPropertyChanging();
					this._mapping_id = value;
					this.SendPropertyChanged("mapping_id");
					this.Onmapping_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="NVarChar(50)")]
		public string user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_guid", DbType="NVarChar(50)")]
		public string file_guid
		{
			get
			{
				return this._file_guid;
			}
			set
			{
				if ((this._file_guid != value))
				{
					this.Onfile_guidChanging(value);
					this.SendPropertyChanging();
					this._file_guid = value;
					this.SendPropertyChanged("file_guid");
					this.Onfile_guidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phy_add", DbType="NVarChar(255)")]
		public string phy_add
		{
			get
			{
				return this._phy_add;
			}
			set
			{
				if ((this._phy_add != value))
				{
					this.Onphy_addChanging(value);
					this.SendPropertyChanging();
					this._phy_add = value;
					this.SendPropertyChanged("phy_add");
					this.Onphy_addChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mapping_name", DbType="NVarChar(50)")]
		public string mapping_name
		{
			get
			{
				return this._mapping_name;
			}
			set
			{
				if ((this._mapping_name != value))
				{
					this.Onmapping_nameChanging(value);
					this.SendPropertyChanging();
					this._mapping_name = value;
					this.SendPropertyChanged("mapping_name");
					this.Onmapping_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_type", DbType="NVarChar(50)")]
		public string file_type
		{
			get
			{
				return this._file_type;
			}
			set
			{
				if ((this._file_type != value))
				{
					this.Onfile_typeChanging(value);
					this.SendPropertyChanging();
					this._file_type = value;
					this.SendPropertyChanged("file_type");
					this.Onfile_typeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_file_size", DbType="Float")]
		public System.Nullable<double> file_size
		{
			get
			{
				return this._file_size;
			}
			set
			{
				if ((this._file_size != value))
				{
					this.Onfile_sizeChanging(value);
					this.SendPropertyChanging();
					this._file_size = value;
					this.SendPropertyChanged("file_size");
					this.Onfile_sizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_map_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> map_dt
		{
			get
			{
				return this._map_dt;
			}
			set
			{
				if ((this._map_dt != value))
				{
					this.Onmap_dtChanging(value);
					this.SendPropertyChanging();
					this._map_dt = value;
					this.SendPropertyChanged("map_dt");
					this.Onmap_dtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_first_uploader", DbType="NVarChar(50)")]
		public string first_uploader
		{
			get
			{
				return this._first_uploader;
			}
			set
			{
				if ((this._first_uploader != value))
				{
					this.Onfirst_uploaderChanging(value);
					this.SendPropertyChanging();
					this._first_uploader = value;
					this.SendPropertyChanged("first_uploader");
					this.Onfirst_uploaderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_map_status", DbType="NVarChar(10)")]
		public string map_status
		{
			get
			{
				return this._map_status;
			}
			set
			{
				if ((this._map_status != value))
				{
					this.Onmap_statusChanging(value);
					this.SendPropertyChanging();
					this._map_status = value;
					this.SendPropertyChanged("map_status");
					this.Onmap_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_play_add", DbType="NVarChar(255)")]
		public string play_add
		{
			get
			{
				return this._play_add;
			}
			set
			{
				if ((this._play_add != value))
				{
					this.Onplay_addChanging(value);
					this.SendPropertyChanging();
					this._play_add = value;
					this.SendPropertyChanged("play_add");
					this.Onplay_addChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
