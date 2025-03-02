using MiniExcelLibs;
using Modbus_MTH_Helper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_MTH
{
    public partial class FrmGroupConfig: Form
    {
        public FrmGroupConfig()
        {
            InitializeComponent();
            this.cmb_StoreArea.DataSource = new string[] { "输入线圈", "输出线圈", "输入寄存器", "输出寄存器" };
            this.dgv_Main.AutoGenerateColumns = false;
            TotalGroups = GetAllGroups();
            //刷新数据
            RefreshGroup();
        }

        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private List<Group> TotalGroups = new List<Group>();

        #region 获取所有的通信组
        /// <summary>
        /// 获取所有的通信组
        /// </summary>
        /// <returns></returns>
        private List<Group> GetAllGroups()
        {
            try
            {
                return MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception)
            {
                return new List<Group>();
            }

        }
        #endregion

        #region 更新通信组集合
        /// <summary>
        /// 更新通信组集合
        /// </summary>
        private void RefreshGroup()
        {
            if (TotalGroups != null && TotalGroups.Count > 0)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = TotalGroups;
            }
        }
        #endregion

        #region 判断通信组是否存在
        /// <summary>
        /// 判断通信组是否存在
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private bool isGroupNameExits(string groupName)
        {
            return TotalGroups.FindAll(c => c.GroupName == groupName).ToList().Count > 0;
        }
        #endregion

        #region 增删改通信组
        /// <summary>
        /// 添加通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (groupName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("通信组名称不能为空！", "添加通信组").Show();
                return;
            }

            if (isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称已经存在！", "添加通信组").Show();
                return;
            }

            TotalGroups.Add(new Group()
            {
                GroupName = groupName,
                Start = Convert.ToUInt16(this.num_Start.Value),
                Length = Convert.ToUInt16(this.num_Length.Value),
                StoreArea = this.cmb_StoreArea.Text.Trim(),
                Remark = this.txt_Remark.Text.Trim()
            });

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                new FrmMsgBoxWithoutAck("添加通信组成功", "添加通信组").Show();

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加通信组失败:" + ex.Message, "添加通信组").Show();
            }
        }

        /// <summary>
        /// 删除通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (!isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "删除通信组").Show();
                return;
            }

            TotalGroups.RemoveAll(c => c.GroupName == groupName);

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除通信组失败:" + ex.Message, "删除通信组").Show();
            }
        }

        /// <summary>
        /// 修改通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (!isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "修改通信组").Show();
                return;
            }

            var group = TotalGroups.Find(c => c.GroupName == groupName);

            group.Start = Convert.ToUInt16(this.num_Start.Value);
            group.Length = Convert.ToUInt16(this.num_Length.Value);
            group.StoreArea = this.cmb_StoreArea.Text.Trim();
            group.Remark = this.txt_Remark.Text.Trim();

            try
            {
                MiniExcel.SaveAs(groupPath, TotalGroups, overwriteFile: true);

                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改通信组失败:" + ex.Message, "修改通信组").Show();
            }
        }
        #endregion

        #region 无边框拖动
        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        #region DataGridView事件
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object value = this.dgv_Main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value == null || value.ToString().Length == 0)
                {
                    e.Value = "---";
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateGroup(TotalGroups[e.RowIndex]);
            }
        }
        private void UpdateGroup(Group group)
        {
            if (group != null)
            {
                this.txt_GroupName.Text = group.GroupName;
                this.num_Start.Text = group.Start.ToString();
                this.num_Length.Text = group.Length.ToString();
                this.cmb_StoreArea.Text = group.StoreArea;
                this.txt_Remark.Text = group.Remark;
            }
        }
        #endregion
    }
}
