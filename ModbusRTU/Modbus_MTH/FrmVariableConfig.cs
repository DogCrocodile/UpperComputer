using MiniExcelLibs;
using Modbus_MTH_Helper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace Modbus_MTH
{
    public partial class FrmVariableConfig : Form
    {
        public FrmVariableConfig()
        {
            InitializeComponent();

            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType));

            this.dgv_Main.AutoGenerateColumns = false;

            List<Group> TotalGroups = GetAllGroups();

            TotalVariables = GetAllVariables();

            this.cmb_GroupName.SelectedIndexChanged += Cmb_GroupName_SelectedIndexChanged;

            if (TotalGroups.Count > 0)
            {
                foreach (var item in TotalGroups)
                {
                    if(item.GroupName == null)
                    {
                        break;
                    }
                    this.cmb_GroupName.Items.Add(item.GroupName);
                }
                this.cmb_GroupName.SelectedIndex = 0;
            }
        }

        private void Cmb_GroupName_SelectedIndexChanged(object sender,EventArgs e)
        {
            RefreshVariable();
        }

        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        private List<Variable> TotalVariables = new List<Variable>();


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

        #region 获取所有的变量
        private List<Variable> GetAllVariables()
        {
            try
            {
                return MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception)
            {
                return new List<Variable>();
            }
        }
        #endregion

        #region 根据通信组名称筛选
        private List<Variable> GetVariablesByGroupName(string groupName)
        {
            if (groupName.Length == 0)
            {
                return TotalVariables;
            }
            else
            {
                return TotalVariables.FindAll(c => c.GroupName == groupName).ToList();
            }
        }
        #endregion

        #region 更新变量集合
        /// <summary>
        /// 更新变量集合
        /// </summary>
        private void RefreshVariable()
        {
            var List = GetVariablesByGroupName(this.cmb_GroupName.Text.Trim());

            if(List != null && List.Count > 0)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = List;
            }            
        }
        #endregion

        #region 判断变量名称是否存在
        /// <summary>
        /// 判断通信组是否存在
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        private bool isVariableNameExits(string variableName)
        {
            return TotalVariables.FindAll(c => c.VarName == variableName).ToList().Count > 0;
        }
        #endregion

        #region 增删改变量
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string varName = this.txt_VarName.Text.Trim();

            if (varName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("变量名称不能为空！", "添加变量").Show();
                return;
            }

            if (isVariableNameExits(varName))
            {
                new FrmMsgBoxWithoutAck("变量名称已经存在！", "添加变量").Show();
                return;
            }

            TotalVariables.Add(new Variable()
            {
                VarName = varName,
                Start = Convert.ToUInt16(this.num_Start.Value),
                OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value),
                DataType = this.cmb_DataType.Text.Trim(),
                GroupName = this.cmb_GroupName.Text.Trim(),
                PosAlarm = this.chk_PosAlarm.Checked,
                NegAlarm = this.chk_NegAlarm.Checked,
                Scale = Convert.ToSingle(this.num_Scale.Value),
                Offset = Convert.ToSingle(this.num_Offset.Value),
                Remark = this.txt_Remark.Text.Trim()
            });

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                new FrmMsgBoxWithoutAck("添加变量成功", "添加变量").Show();

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加变量失败:" + ex.Message, "添加变量").Show();
            }
        }

        /// <summary>
        /// 删除通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!isVariableNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").Show();
                return;
            }

            TotalVariables.RemoveAll(c => c.VarName == variableName);

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除变量失败:" + ex.Message, "删除变量").Show();
            }
        }

        /// <summary>
        /// 修改通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!isVariableNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").Show();
                return;
            }

            var variable = TotalVariables.Find(c => c.VarName == variableName);

            variable.Start = Convert.ToUInt16(this.num_Start.Value);
            variable.OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value);
            variable.DataType = cmb_DataType.Text.Trim();
            variable.GroupName = this.cmb_GroupName.Text.Trim();
            variable.PosAlarm = this.chk_PosAlarm.Checked;
            variable.NegAlarm = this.chk_NegAlarm.Checked;
            variable.Scale = Convert.ToSingle(this.num_Scale.Value);
            variable.Offset = Convert.ToSingle(this.num_Offset.Value);
            variable.Remark = this.txt_Remark.Text.Trim();

            try
            {
                MiniExcel.SaveAs(variablePath, TotalVariables, overwriteFile: true);

                //刷新数据
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改变量失败:" + ex.Message, "修改变量").Show();
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
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object value = this.dgv_Main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if(e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {
                    if(value != null)
                    {
                        e.Value = value.ToString() == "True" ? "启用" : "禁用";
                    }
                    else
                    {
                        if (value == null || value.ToString().Length == 0)
                        {
                            e.Value = "---";
                        }
                    }
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
                UpdateVariable(TotalVariables[e.RowIndex]);
            }
        }
        private void UpdateVariable(Variable variable)
        {
            if (variable!= null)
            {
                this.cmb_GroupName.Text = variable.GroupName;
                this.txt_VarName.Text = variable.VarName;
                this.num_Start.Text = variable.Start.ToString();
                this.num_Start.Text = variable.Start.ToString();
                this.num_OffsetOrLength.Text = variable.OffsetOrLength.ToString();
                this.cmb_DataType.Text = variable.DataType;
                this.chk_PosAlarm.Checked = variable.PosAlarm;
                this.chk_NegAlarm.Checked = variable.NegAlarm;
                this.num_Scale.Value = Convert.ToDecimal(variable.Scale);
                this.num_Offset.Value = Convert.ToDecimal(variable.Offset);
                this.txt_Remark.Text = variable.Remark;
            }
        }

        #endregion

    }
}
