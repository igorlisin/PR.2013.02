using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRInterfaces.Interfaces;

namespace PRParser
{
    public partial class FactorRateForm : Form
    {
        private IComparisonApart[] _aparts;

        public FactorRateForm(IComparisonApart[] aparts)
        {
            _aparts = aparts;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            groupBox1.Text = _aparts[0].address;
            groupBox2.Text = _aparts[1].address;
            groupBox3.Text = _aparts[2].address;
            groupBox4.Text = _aparts[3].address;
            groupBox5.Text = _aparts[4].address;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            float sqmPrice1 = _aparts[0].price*1000 / _aparts[0].grossArea;
            float sqmPrice2 = _aparts[1].price*1000 / _aparts[1].grossArea;
            float sqmPrice3 = _aparts[2].price*1000 / _aparts[2].grossArea;
            float sqmPrice4 = _aparts[3].price*1000 / _aparts[3].grossArea;
            float sqmPrice5 = _aparts[4].price*1000 / _aparts[4].grossArea;

            _aparts[0].kTorg = Convert.ToSingle(kTorgTextBox1.Text)/100;
            _aparts[0].kFloors = Convert.ToSingle(kFloorsTextBox1.Text) / 100;
            _aparts[0].kFloor = Convert.ToSingle(kFloorTextBox1.Text) / 100;
            _aparts[0].kBalcon = Convert.ToSingle(kBalconTextBox1.Text) / 100;
            _aparts[0].kSanuzel = Convert.ToSingle(kSanuzelTextBox1.Text) / 100;
            _aparts[0].kSKitchen = Convert.ToSingle(kSKitchenTextBox1.Text) / 100;
            _aparts[0].kWallType = Convert.ToSingle(kWallTypeTextBox1.Text) / 100;
            _aparts[0].finishingQualityPrice = Convert.ToSingle(finishingQualityPriceTextBox1.Text);
            _aparts[0].statePrice = Convert.ToSingle(StateTextBox1.Text);
            _aparts[0].kView = Convert.ToSingle(viewTextBox1.Text)/100;
            _aparts[0].sqmCalcPrice = sqmPrice1 + sqmPrice1 * _aparts[0].kTorg +
                                                sqmPrice1 * _aparts[0].kFloors +
                                                sqmPrice1 * _aparts[0].kFloor +
                                                sqmPrice1 * _aparts[0].kBalcon +
                                                sqmPrice1 * _aparts[0].kSanuzel +
                                                sqmPrice1 * _aparts[0].kSKitchen +
                                                sqmPrice1 * _aparts[0].kWallType +
                                                 _aparts[0].finishingQualityPrice +
                                                sqmPrice1 * _aparts[0].kView;

            _aparts[1].kTorg = Convert.ToSingle(kTorgTextBox2.Text) / 100;
            _aparts[1].kFloors = Convert.ToSingle(kFloorsTextBox2.Text) / 100;
            _aparts[1].kFloor = Convert.ToSingle(kFloorTextBox2.Text) / 100;
            _aparts[1].kBalcon = Convert.ToSingle(kBalconTextBox2.Text) / 100;
            _aparts[1].kSanuzel = Convert.ToSingle(kSanuzelTextBox2.Text) / 100;
            _aparts[1].kSKitchen = Convert.ToSingle(kSKitchenTextBox2.Text) / 100;
            _aparts[1].kWallType = Convert.ToSingle(kWallTypeTextBox2.Text) / 100;
            _aparts[1].finishingQualityPrice = Convert.ToSingle(finishingQualityPriceTextBox2.Text);
            _aparts[1].statePrice = Convert.ToSingle(StateTextBox2.Text);
            _aparts[1].kView = Convert.ToSingle(viewTextBox2.Text)/100;
            _aparts[1].sqmCalcPrice = sqmPrice2 + sqmPrice2 * _aparts[1].kTorg +
                                    sqmPrice2 * _aparts[1].kFloors +
                                    sqmPrice2 * _aparts[1].kFloor +
                                    sqmPrice2 * _aparts[1].kBalcon +
                                    sqmPrice2 * _aparts[1].kSanuzel +
                                    sqmPrice2 * _aparts[1].kSKitchen +
                                    sqmPrice2 * _aparts[1].kWallType +
                                     _aparts[1].finishingQualityPrice +
                                    sqmPrice2 * _aparts[1].kView;

            _aparts[2].kTorg = Convert.ToSingle(kTorgTextBox3.Text) / 100;
            _aparts[2].kFloors = Convert.ToSingle(kFloorsTextBox3.Text) / 100;
            _aparts[2].kFloor = Convert.ToSingle(kFloorTextBox3.Text) / 100;
            _aparts[2].kBalcon = Convert.ToSingle(kBalconTextBox3.Text) / 100;
            _aparts[2].kSanuzel = Convert.ToSingle(kSanuzelTextBox3.Text) / 100;
            _aparts[2].kSKitchen = Convert.ToSingle(kSKitchenTextBox3.Text) / 100;
            _aparts[2].kWallType = Convert.ToSingle(kWallTypeTextBox3.Text) / 100;
            _aparts[2].finishingQualityPrice = Convert.ToSingle(finishingQualityPriceTextBox3.Text);
            _aparts[2].statePrice = Convert.ToSingle(StateTextBox3.Text);
            _aparts[2].kView = Convert.ToSingle(viewTextBox3.Text)/100;
            _aparts[2].sqmCalcPrice = sqmPrice3 + sqmPrice3 * _aparts[2].kTorg +
                                    sqmPrice3 * _aparts[2].kFloors +
                                    sqmPrice3 * _aparts[2].kFloor +
                                    sqmPrice3 * _aparts[2].kBalcon +
                                    sqmPrice3 * _aparts[2].kSanuzel +
                                    sqmPrice3 * _aparts[2].kSKitchen +
                                    sqmPrice3 * _aparts[2].kWallType +
                                     _aparts[2].finishingQualityPrice +
                                    sqmPrice3 * _aparts[2].kView;

            _aparts[3].kTorg = Convert.ToSingle(kTorgTextBox4.Text) / 100;
            _aparts[3].kFloors = Convert.ToSingle(kFloorsTextBox4.Text) / 100;
            _aparts[3].kFloor = Convert.ToSingle(kFloorTextBox4.Text) / 100;
            _aparts[3].kBalcon = Convert.ToSingle(kBalconTextBox4.Text) / 100;
            _aparts[3].kSanuzel = Convert.ToSingle(kSanuzelTextBox4.Text) / 100;
            _aparts[3].kSKitchen = Convert.ToSingle(kSKitchenTextBox4.Text) / 100;
            _aparts[3].kWallType = Convert.ToSingle(kWallTypeTextBox4.Text) / 100;
            _aparts[3].finishingQualityPrice = Convert.ToSingle(finishingQualityPriceTextBox4.Text);
            _aparts[3].statePrice = Convert.ToSingle(StateTextBox4.Text);
            _aparts[3].kView = Convert.ToSingle(viewTextBox4.Text)/100;
            _aparts[3].sqmCalcPrice = sqmPrice4 + sqmPrice4 * _aparts[3].kTorg +
                                    sqmPrice4 * _aparts[3].kFloors +
                                    sqmPrice4 * _aparts[3].kFloor +
                                    sqmPrice4 * _aparts[3].kBalcon +
                                    sqmPrice4 * _aparts[3].kSanuzel +
                                    sqmPrice4 * _aparts[3].kSKitchen +
                                    sqmPrice4 * _aparts[3].kWallType +
                                     _aparts[3].finishingQualityPrice +
                                    sqmPrice4 * _aparts[3].kView;

            _aparts[4].kTorg = Convert.ToSingle(kTorgTextBox5.Text) / 100;
            _aparts[4].kFloors = Convert.ToSingle(kFloorsTextBox5.Text) / 100;
            _aparts[4].kFloor = Convert.ToSingle(kFloorTextBox5.Text) / 100;
            _aparts[4].kBalcon = Convert.ToSingle(kBalconTextBox5.Text) / 100;
            _aparts[4].kSanuzel = Convert.ToSingle(kSanuzelTextBox5.Text) / 100;
            _aparts[4].kSKitchen = Convert.ToSingle(kSKitchenTextBox5.Text) / 100;
            _aparts[4].kWallType = Convert.ToSingle(kWallTypeTextBox5.Text) / 100;
            _aparts[4].finishingQualityPrice = Convert.ToSingle(finishingQualityPriceTextBox5.Text);
            _aparts[4].statePrice = Convert.ToSingle(StateTextBox5.Text);
            _aparts[4].kView = Convert.ToSingle(viewTextBox5.Text)/100;
            _aparts[4].sqmCalcPrice = sqmPrice5 + sqmPrice5 * _aparts[4].kTorg +
                                    sqmPrice5 * _aparts[4].kFloors +
                                    sqmPrice5 * _aparts[4].kFloor +
                                    sqmPrice5 * _aparts[4].kBalcon +
                                    sqmPrice5 * _aparts[4].kSanuzel +
                                    sqmPrice5 * _aparts[4].kSKitchen +
                                    sqmPrice5 * _aparts[4].kWallType +
                                     _aparts[4].finishingQualityPrice +
                                    sqmPrice5 * _aparts[4].kView;
            this.Close();
        }
    }
}
