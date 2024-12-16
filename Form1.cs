using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;
using DA2419_Application_VS19.Component;
using System.Runtime.Remoting.Messaging;

namespace DA2419_Application_VS19
{
    public partial class Form1 : Form
    {
        // Importing CreateRoundRectRgn function from gdi32.dll để tạo bo cong cho panel
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        #region Globar variables

        // Biến timer
        private Timer blinkTimer;
        private Timer mouseLeaveTimerPos1, mouseLeaveTimerPos2, mouseLeaveTimerPos3, mouseLeaveTimerPos4; // Timer xảy ra khi di chuyển chuột ra khỏi nút nhấn
        // Biến trạng thái hoạt động 
        private bool isButtonVisible = true; // Kiểm tra LED auto mode có sáng hay không
        // Panels cho popup menus
        private Panel popupMore1;
        private Panel popupMore2;
        private Panel popupMore3;
        private Panel popupMore4;
        // BIến nút nhấn lưu và xóa
        private ActionButton btnSavePos1;
        private ActionButton btnDelPos1;
        private ActionButton btnSavePos2;
        private ActionButton btnDelPos2;
        private ActionButton btnSavePos3;
        private ActionButton btnDelPos3;
        private ActionButton btnSavePos4;
        private ActionButton btnDelPos4;
        #region Variable color
        private readonly Color bgFormColor = ColorTranslator.FromHtml("#272727");
        private readonly Color textColor = ColorTranslator.FromHtml("#ebe9fc");
        private readonly Color textSecondaryColor = ColorTranslator.FromHtml("#cec9f8");
        private readonly Color bgCardColor = ColorTranslator.FromHtml("#3D3D3D");
        private readonly Color bgBlack = ColorTranslator.FromHtml("#1E1E1E");

        private readonly Color accentColor = ColorTranslator.FromHtml("#ed6a11");
        private readonly Color accentColor300 = ColorTranslator.FromHtml("#F9B49F");
        private readonly Color accentColor700 = ColorTranslator.FromHtml("#F58766");
        private readonly Color grayColor = ColorTranslator.FromHtml("#696969");
        private readonly Color emergencyColor = ColorTranslator.FromHtml("#f92f60");
        private readonly Color activeColor = ColorTranslator.FromHtml("#00d26a");
        private readonly Color primaryColor = ColorTranslator.FromHtml("#003262");
        private readonly Color secondaryColor = ColorTranslator.FromHtml("#020024");
        #endregion

        #region Variable of Project
        float distanceLimtit = 155;// Khoảng cách của 2 limit (mm)
        int threadPitch = 3; // Bước ren
        int pulsesPerRevolution = 3600; // xung/vòng
        float distanceMove; // Khoảng cách di chuyên của đầu đo
        float minSpeed = 2; // Tốc độ tối thiểu của trục Z (m/s)
        float maxSpeed = 10; // Tốc độ tối đa của trục Z (m/s)
        int minCoordinateZ = -155; // Tọa độ min của trục Z (mm)
        int maxCoordinateZ = 0; // Tọa độ max của trục Z (mm)
        #endregion

        #endregion
        public Form1()
        {
            InitializeComponent();
            /// <summary>
            /// Khổi tạo timer cho sự kiện mouse leave
            /// Tạo delay cho sự kiện mouse leave để khi di chuyển chuột ra khỏi nút nhấn thì panel không biến mất ngay lập tức
            /// </summary>
            #region Variable of more button
            mouseLeaveTimerPos1 = new Timer();
            mouseLeaveTimerPos1.Interval = 150; // Check after 150ms
            mouseLeaveTimerPos1.Tick += MouseLeaveTimerPos1_Tick; // Khởi tạo function timer

            mouseLeaveTimerPos2 = new Timer();
            mouseLeaveTimerPos2.Interval = 150; // Check after 150ms
            mouseLeaveTimerPos2.Tick += MouseLeaveTimerPos2_Tick;

            mouseLeaveTimerPos3 = new Timer();
            mouseLeaveTimerPos3.Interval = 150; // Check after 150ms
            mouseLeaveTimerPos3.Tick += MouseLeaveTimerPos3_Tick;

            mouseLeaveTimerPos4 = new Timer();
            mouseLeaveTimerPos4.Interval = 150; // Check after 150ms
            mouseLeaveTimerPos4.Tick += MouseLeaveTimerPos4_Tick;
            #endregion

            #region Application UI
            // Form
            this.BackColor = bgFormColor; // Background color
            this.ForeColor = textColor; // Text color
            this.Width = 278;
            this.Height = 746;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Cài đặt giá trị đầu vào max của textbox position
            inputPos1.MaxValue = maxCoordinateZ;
            inputPos2.MaxValue = maxCoordinateZ;
            inputPos3.MaxValue = maxCoordinateZ;
            inputPos4.MaxValue = maxCoordinateZ;
            // Cài đặt giá trị đầu vào min của textbox position
            inputPos1.MinValue = minCoordinateZ;
            inputPos2.MinValue = minCoordinateZ;
            inputPos3.MinValue = minCoordinateZ;
            inputPos4.MinValue = minCoordinateZ;


            // State
            #region State
            // Label
            stateLabel.ForeColor = textColor; // set text color for label
            stateLabel.Text = "Auto mode"; // set text content for label
            // Active led state 
            activeState.Size = new Size(20, 20);
            activeState.Position = new Point(152, 9);

            #endregion

            //Coordinate Card 
            #region Coordinate card
            coordianteLabel.ForeColor = accentColor;
            coordianteLabel.Font = new Font(controlLabel.Font, FontStyle.Bold);
            coordinateCard.BackColor = bgCardColor;
            coordinateCard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, coordinateCard.Width, coordinateCard.Height, 10, 10)); // Function to draw panel with border radious
            // active led of limit in home position
            limitHome.State = ActiveButton.ButtonState.Emergency; // state color of active led property
            limitHome.Size = new Size(16, 16);
            // active led of limit in bottom position
            limitNe.State = ActiveButton.ButtonState.Emergency; // state color of active led property
            limitNe.Size = new Size(16, 16);
            // active led of current positon
            currentPos.State = ActiveButton.ButtonState.Active; // state color of active led property
            currentPos.Size = new Size(16, 16);

            // Initialize and start the blink timer
            blinkTimer = new Timer();
            blinkTimer.Interval = 300; // set delay time
            blinkTimer.Tick += BlinkTimer_Tick; // create funtion that performs a task when called
            blinkTimer.Start(); // start delay time
            #endregion

            // Control card
            #region Control card
            controlLabel.ForeColor = accentColor;
            controlLabel.Font = new Font(controlLabel.Font, FontStyle.Bold);
            controlCard.BackColor = bgCardColor;
            controlCard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, controlCard.Width, controlCard.Height, 10, 10)); // Function to draw panel with border radious
            // Button control 
            // Resize image of button control z axis
            btnUpHigh.Image = ResizeImage(Properties.Resources.icon_double_up, 24, 24); // call function to resize image of button
            btnUp.Image = ResizeImage(Properties.Resources.icon_up, 24, 24);
            btnHome.Image = ResizeImage(Properties.Resources.icon_home, 24, 24);
            btnDown.Image = ResizeImage(Properties.Resources.icon_down, 24, 24);
            btnDownHigh.Image = ResizeImage(Properties.Resources.icon_double_down, 24, 24);
            // Cursor event
            btnUpHigh.Cursor = Cursors.Hand;
            btnHome.Cursor = Cursors.Hand;
            btnUp.Cursor = Cursors.Hand;
            btnDown.Cursor = Cursors.Hand;
            btnDownHigh.Cursor = Cursors.Hand;
            // Background of button control z axis
            #region BG bgBlack
            btnUpHigh.BackColor = bgBlack;
            btnHome.BackColor = bgBlack;
            btnUp.BackColor = bgBlack;
            btnDown.BackColor = bgBlack;
            btnDownHigh.BackColor = bgBlack;
            #endregion
            // Handle event change background color when mouse enter and left of button that controls the z axis
            #region Event button
            btnUpHigh.MouseEnter += HandleMouseEnterButton;
            btnUpHigh.MouseLeave += HandleMouseLeaveButton;

            btnHome.MouseEnter += HandleMouseEnterButton;
            btnHome.MouseLeave += HandleMouseLeaveButton;

            btnUp.MouseEnter += HandleMouseEnterButton;
            btnUp.MouseLeave += HandleMouseLeaveButton;

            btnDown.MouseEnter += HandleMouseEnterButton;
            btnDown.MouseLeave += HandleMouseLeaveButton;

            btnDownHigh.MouseEnter += HandleMouseEnterButton;
            btnDownHigh.MouseLeave += HandleMouseLeaveButton;

            #endregion

            #endregion
            //Change speed Card 
            #region Change speed card
            changeSpeedLabel.ForeColor = accentColor;
            changeSpeedLabel.Font = new Font(controlLabel.Font, FontStyle.Bold);
            changeSpeedCard.BackColor = bgCardColor;
            changeSpeedCard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, changeSpeedCard.Width, changeSpeedCard.Height, 10, 10)); // Function to draw panel with border radious
            currentSpeedLabel.Text = $" {minSpeed.ToString("F2")} mm/s"; // Change the value of current speed from a float type to a string and print it in the format .00 (F2) 
            //TrackBar
            customSlider1.ValueChanged += CustomSlider1_ValueChanged; // Create a function that will perform a task when the value of trackbar changeas
            customSlider1.TrackColorLeft = textColor;
            customSlider1.TrackColorRight = bgBlack;
            customSlider1.ThumbColor = accentColor;
            minSpeedLabel.Text = minSpeed.ToString();
            maxSpeedLabel.Text = maxSpeed.ToString();

            #endregion

            //Teaching card
            autoModeLabel.ForeColor = accentColor;
            autoModeLabel.Font = new Font(controlLabel.Font, FontStyle.Bold);
            autoModeCard.BackColor = bgCardColor;
            autoModeCard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, autoModeCard.Width, autoModeCard.Height, 10, 10)); // Function to draw panel with border radious
            /// <summary>
            /// Note for improve in the next version : 
            /// Create a  function or something to generate multiple action led
            /// </summary>
            //Run button
            #region Run button
            // Active pos 1
            activePos1.Size = new Size(14, 14);
            activePos1.Position = new Point(52, 48);
            activePos1.State = ActiveButton.ButtonState.Normal;
            btnRunPos1.Cursor = Cursors.Hand;
            // Active pos 2
            activePos2.Size = new Size(14, 14);
            activePos2.Position = new Point(52, 78);
            activePos2.State = ActiveButton.ButtonState.Normal;
            btnRunPos2.Cursor = Cursors.Hand;

            // Active pos 3
            activePos3.Size = new Size(14, 14);
            activePos3.Position = new Point(52, 108);
            activePos3.State = ActiveButton.ButtonState.Normal;
            btnRunPos3.Cursor = Cursors.Hand;

            // Active pos 4
            activePos4.Size = new Size(14, 14);
            activePos4.Position = new Point(52, 138);
            activePos4.State = ActiveButton.ButtonState.Normal;
            btnRunPos4.Cursor = Cursors.Hand;

            // Button Run pos 1
            btnRunPos1.Image = ResizeImage(Properties.Resources.icon_start, 12, 12);
            btnRunPos2.Image = ResizeImage(Properties.Resources.icon_start, 12, 12);
            btnRunPos3.Image = ResizeImage(Properties.Resources.icon_start, 12, 12);
            btnRunPos4.Image = ResizeImage(Properties.Resources.icon_start, 12, 12);

            btnRunPos1.MouseEnter += HandleMouseEnterButton;
            btnRunPos1.MouseLeave += HandleMouseLeaveButton;
            btnRunPos2.MouseEnter += HandleMouseEnterButton;
            btnRunPos2.MouseLeave += HandleMouseLeaveButton;
            btnRunPos3.MouseEnter += HandleMouseEnterButton;
            btnRunPos3.MouseLeave += HandleMouseLeaveButton;
            btnRunPos4.MouseEnter += HandleMouseEnterButton;
            btnRunPos4.MouseLeave += HandleMouseLeaveButton;



            btnMorePos1.Image = ResizeImage(Properties.Resources.icon_more, 12, 12);
            btnMorePos2.Image = ResizeImage(Properties.Resources.icon_more, 12, 12);
            btnMorePos3.Image = ResizeImage(Properties.Resources.icon_more, 12, 12);
            btnMorePos4.Image = ResizeImage(Properties.Resources.icon_more, 12, 12);

            btnAutoRun.Cursor = Cursors.Hand;
            btnAutoRun.BackColor = bgBlack;
            btnAutoRun.MouseEnter += HandleMouseEnterButton;
            btnAutoRun.MouseLeave += HandleMouseLeaveButton;
            #endregion
            // Clear all label
            // Thay đổi màu chữ của clearALlLabel khi di chuyển chuột vào, ra
            clearAllLabel.MouseEnter += (s, e) => clearAllLabel.ForeColor = accentColor;
            clearAllLabel.MouseLeave += (s, e) => clearAllLabel.ForeColor = textColor;
            clearAllLabel.MouseClick += ClearAllLabel_MouseClick; // Create funtion that is triggred when the CLear all label is clicked
            clearAllLabel.Cursor = Cursors.Hand;

            /// <summary>
            /// Note for improve in the next version : 
            /// Create a  function or something to generate multiple hidden panel and save, delete button
            /// </summary>
            // Panel hidden 1
            #region Button more pos 1
            // Tạo ra panelMore1 ( tương tự như kéo toolbox vào vùng design)
            popupMore1 = new Panel // Change property of UI
            {
                Size = new Size(82, 70),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Cursor = Cursors.Hand,
            };
            this.Controls.Add(popupMore1); // Generate Panel
            popupMore1.MouseEnter += popupMore1_MouseEnter; // Create fuction that is triggerd when panel hidden 1 is mouse enter 
            popupMore1.MouseLeave += popupMore1_MouseLeave; // Create fuction that is triggerd when panel hidden 1 is mouse leave

            // Nút nhấn lưu tọa độ teaching
            #region Button Save Pos 1
            btnSavePos1 = new ActionButton // Change property of UI
            {
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_save, 20, 20),
                ButtonText = "Save",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor
            };
            // Thay đổi background của nút nhấn khi MouseEnter & MouseLeave
            btnSavePos1.MouseEnter += btnShowPos1_MouseEnter;
            btnSavePos1.MouseLeave += btnShowPos1_MouseLeave;
            // Function xử lí logic cho sự kiện MouseEnter & MouseLeave
            btnSavePos1.MouseEnter += btnSavePos1_MouseEnter;
            btnSavePos1.MouseLeave += btnSavePos1_MouseLeave;
            // Handle function when click button save position
            btnSavePos1.MouseClick += btnSavePos1_MouseClick;
            #endregion

            // Button delete
            #region Button Delete Pos 1
            btnDelPos1 = new ActionButton // Change property of UI
            {
                Location = new Point(0, 34),
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_delete, 18, 18),
                ButtonText = "Delete",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor
            };
            // Thay đổi background của nút nhấn khi MouseEnter & MouseLeave
            btnDelPos1.MouseEnter += btnShowPos1_MouseEnter;
            btnDelPos1.MouseLeave += btnShowPos1_MouseLeave;
            // Function xử lí logic cho sự kiện MouseEnter & MouseLeave
            btnDelPos1.MouseEnter += btnDelPos1_MouseEnter;
            btnDelPos1.MouseLeave += btnDelPos1_MouseLeave;
            // Handle function when click button delete position
            btnDelPos1.MouseClick += btnDelPos1_MouseClick;


            #endregion
            // Tạo nút nhấn save và delete năm trong pannelMore1
            popupMore1.Controls.Add(btnSavePos1);
            popupMore1.Controls.Add(btnDelPos1);

            #endregion

            // Panel hidden 2
            #region Button more pos 2
            popupMore2 = new Panel
            {
                Size = new Size(82, 70),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Cursor = Cursors.Hand
            };
            this.Controls.Add(popupMore2);

            // Button save ver2
            #region Button Save Pos 2
            btnSavePos2 = new ActionButton
            {
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_save, 20, 20),
                ButtonText = "Save",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor

            };
            btnSavePos2.MouseEnter += btnShowPos2_MouseEnter;
            btnSavePos2.MouseLeave += btnShowPos2_MouseLeave;

            btnSavePos2.MouseEnter += btnSavePos2_MouseEnter;
            btnSavePos2.MouseLeave += btnSavePos2_MouseLeave;

            btnSavePos2.MouseClick += btnSavePos2_MouseClick;
            #endregion

            // Button delete
            #region Button Delete Pos 2
            btnDelPos2 = new ActionButton
            {
                Location = new Point(0, 34),
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_delete, 18, 18),
                ButtonText = "Delete",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor
            };
            btnDelPos2.MouseEnter += btnShowPos2_MouseEnter;
            btnDelPos2.MouseLeave += btnShowPos2_MouseLeave;
            btnDelPos2.MouseEnter += btnDelPos2_MouseEnter;
            btnDelPos2.MouseLeave += btnDelPos2_MouseLeave;

            btnDelPos2.MouseClick += btnDelPos2_MouseClick;

            #endregion

            popupMore2.Controls.Add(btnSavePos2);
            popupMore2.Controls.Add(btnDelPos2);
            #endregion

            // Panel hidden 3
            #region Button more pos 3
            popupMore3 = new Panel
            {
                Size = new Size(82, 70),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Cursor = Cursors.Hand
            };
            this.Controls.Add(popupMore3);

            // Button save ver3
            #region Button Save Pos 3
            btnSavePos3 = new ActionButton
            {
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_save, 20, 20),
                ButtonText = "Save",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor

            };
            btnSavePos3.MouseEnter += btnShowPos3_MouseEnter;
            btnSavePos3.MouseLeave += btnShowPos3_MouseLeave;

            btnSavePos3.MouseEnter += btnSavePos3_MouseEnter;
            btnSavePos3.MouseLeave += btnSavePos3_MouseLeave;

            btnSavePos3.MouseClick += btnSavePos3_MouseClick;
            #endregion

            // Button delete
            #region Button Delete Pos 3
            btnDelPos3 = new ActionButton
            {
                Location = new Point(0, 34),
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_delete, 18, 18),
                ButtonText = "Delete",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor
            };
            btnDelPos3.MouseEnter += btnShowPos3_MouseEnter;
            btnDelPos3.MouseLeave += btnShowPos3_MouseLeave;
            btnDelPos3.MouseEnter += btnDelPos3_MouseEnter;
            btnDelPos3.MouseLeave += btnDelPos3_MouseLeave;

            btnDelPos3.MouseClick += btnDelPos3_MouseClick;

            #endregion

            popupMore3.Controls.Add(btnSavePos3);
            popupMore3.Controls.Add(btnDelPos3);
            #endregion

            // Panel hidden 4
            #region Button more pos 4
            popupMore4 = new Panel
            {
                Size = new Size(82, 70),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Cursor = Cursors.Hand
            };
            this.Controls.Add(popupMore4);

            // Button save ver4
            #region Button Save Pos 4
            btnSavePos4 = new ActionButton
            {
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_save, 20, 20),
                ButtonText = "Save",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor

            };
            btnSavePos4.MouseEnter += btnShowPos4_MouseEnter;
            btnSavePos4.MouseLeave += btnShowPos4_MouseLeave;

            btnSavePos4.MouseEnter += btnSavePos4_MouseEnter;
            btnSavePos4.MouseLeave += btnSavePos4_MouseLeave;

            btnSavePos4.MouseClick += btnSavePos4_MouseClick;
            #endregion

            // Button delete
            #region Button Delete Pos 4
            btnDelPos4 = new ActionButton
            {
                Location = new Point(0, 34),
                Size = new Size(80, 34),
                BackColor = bgBlack,
                Image = ResizeImage(Properties.Resources.icon_delete, 18, 18),
                ButtonText = "Delete",
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0),
                TextPadding = new Padding(10, 0, 0, 0),
                BorderRadius = 0,
                BorderColor = grayColor
            };
            btnDelPos4.MouseEnter += btnShowPos4_MouseEnter;
            btnDelPos4.MouseLeave += btnShowPos4_MouseLeave;
            btnDelPos4.MouseEnter += btnDelPos4_MouseEnter;
            btnDelPos4.MouseLeave += btnDelPos4_MouseLeave;

            btnDelPos4.MouseClick += btnDelPos4_MouseClick;

            #endregion

            popupMore4.Controls.Add(btnSavePos4);
            popupMore4.Controls.Add(btnDelPos4);
            #endregion

            #endregion

            #region KV COM+
            // Fire when teaching bit trigger
            // Checking if remove function
            //axDBTriggerManager1.Triggers.FindByName("TriggerTch").Fire += TeachingChange_Fire;

            // Fire when auto mode trigger (when MR100 on)
            axDBTriggerManager1.Triggers.FindByName("TriggerAutoMode").Fire += AutoMode_Fire;
            //axDBTriggerManager1.Triggers.FindByName("TriggerAutoMode").Fire += AutoMode_Fire;



            //InitializeTriggersForFloatValues();
            #endregion

        }


        /// <summary>
        /// LED mode thay đổi theo trạng thái của chương trình :
        /// Nếu chương trình ở trạng thái đang chạy về home thì LED sẽ sáng màu xanh lá cây, mặc định là màu xám
        /// 1. Đọc dữ liệu từ thanh ghi 8405 (8405 is register that is on when comming home position)
        /// 2. Gán giá trị cho biến isRunning để kiểm tra trạng thái
        /// 3. Màu sắc của LED sẽ thay đổi dựa theo trạng thái của chương trình
        /// </summary>
        private void AutoMode_Fire(DATABUILDERAXLibLB.DBTrigger pTrigger)
        {
            int isRunning = axDBCommManager1.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNanoXYM_CR, "8404");
            if (isRunning != 0 )
            {
                activeState.State = ActiveButton.ButtonState.Active;
            }
            else
            {
                activeState.State = ActiveButton.ButtonState.Normal;
            }

            Console.WriteLine("run");
        }
        // delete if no need
        private void TeachingChange_Fire(DATABUILDERAXLibLB.DBTrigger pTrigger)
        {
            try
            {
                // Create a dictionary for address pairs and associated textboxes
                var addressTextboxMapping = new Dictionary<(string lower, string upper), TextBox>
        {
            { ("8000", "8001"), inputPos1 }, // CM8000/CM8001 -> textBoxCM8000
            { ("8010", "8011"), inputPos2 }, // CM8010/CM8011 -> textBoxCM8010
            { ("8020", "8021"), inputPos3 }, // CM8020/CM8021 -> textBoxCM8020
            { ("8030", "8031"), inputPos4 }  // CM8030/CM8031 -> textBoxCM8030
        };

                foreach (var pair in addressTextboxMapping)
                {
                    // Read the lower and upper words
                    int lowerWord = axDBCommManager1.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_CM, pair.Key.lower);
                    int upperWord = axDBCommManager1.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_CM, pair.Key.upper);

                    // Combine the two 16-bit words into a 32-bit integer
                    float combined = (upperWord << 16) | lowerWord;
                    pair.Value.Text = (combined / (pulsesPerRevolution / threadPitch)).ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or converting data: {ex.Message}");
            }
        }
        // delete if no need
        public void InitializeTriggersForFloatValues()
        {
            try
            {
                // Define the address pairs and corresponding textboxes
                var addressPairs = new (string lowerWord, string upperWord, TextBox targetTextbox)[]
                {
                ("22", "23", inputPos1),
                ("30", "31", inputPos2),
                ("38", "39", inputPos3),
                ("46", "47", inputPos4)
                };

                int deviceNumber = 1;

                // Set up a trigger for each address pair
                foreach (var (lowerWord, upperWord, targetTextbox) in addressPairs)
                {
                    var trigger = axDBTriggerManager1.Triggers.Add(DATABUILDERAXLibLB.DBAxTriggerType.ttDevice);
                    trigger.Name = $"Trigger_{lowerWord}_{upperWord}";
                    trigger.Description = $"Trigger to monitor DM{lowerWord} and DM{upperWord}";

                    // Use AsDevice to specify the device and address
                    var deviceParam = trigger.AsDevice;
                    deviceParam.DeviceNo = deviceNumber.ToString();

                    deviceNumber++; // Increment the device number

                    // Enable the trigger for this device
                    trigger.Fire += new DATABUILDERAXLibLB._IDBTriggerEvents_FireEventHandler((sender) =>
                    {
                        Console.WriteLine($"Trigger fired for DM{lowerWord} and DM{upperWord}");
                        UpdateFloatTextbox(lowerWord, upperWord, targetTextbox);
                    });
                }

                MessageBox.Show("Triggers for all address pairs initialized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing triggers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Note for improve in the next version:
        /// Make this function shorter by ValueRead dont need create devices for save data 
        /// </summary>
        // Đọc giá trị tọa độ điểm teaching khi lần đầu chạy chương trình
        private void UpdateFloatTextbox(string lowerWord, string upperWord, TextBox targetTextbox)
        {
            DATABUILDERAXLibLB.DBDevice lowerDevice = null;
            DATABUILDERAXLibLB.DBDevice upperDevice = null;

            try
            {
                // Create devices to read data from the PLC for lower and upper words
                lowerDevice = axDBDeviceManager1.Devices.Add(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, lowerWord);
                upperDevice = axDBDeviceManager1.Devices.Add(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, upperWord);

                // No need for BeforeRead; use ValueRead directly to get the latest values
                ushort lowerValue = (ushort)lowerDevice.ValueRead;
                ushort upperValue = (ushort)upperDevice.ValueRead;

                // Combine the two 16-bit words into a 32-bit integer
                uint combinedValue = (uint)((upperValue << 16) | lowerValue);

                // Convert to float
                float floatValue = BitConverter.ToSingle(BitConverter.GetBytes(combinedValue), 0);

                // Ensure UI thread safety
                if (targetTextbox.InvokeRequired)
                {
                    targetTextbox.Invoke(new Action(() => targetTextbox.Text = floatValue.ToString("F2")));
                }
                else
                {
                    targetTextbox.Text = floatValue.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading from PLC: {ex.Message}");
            }
            finally
            {
                // Clean up devices
                if (lowerDevice != null)
                {
                    axDBDeviceManager1.Devices.Remove(lowerDevice);
                }
                if (upperDevice != null)
                {
                    axDBDeviceManager1.Devices.Remove(upperDevice);
                }
            }
        }

        /// <summary>
        /// Viết dữ liệu vào thanh ghi DM:
        /// 1. Chuyển data từ float thành int 16 bit
        /// 2. Viết data vào 2 thanh ghi tương ứng (ví dụ DM22,DM23)
        /// </summary>
        private void WritePosToPLC(string lowerWord, string upperWord, float value)
        {
            try
            {
                // Chuyển float data thành 32 bit data
                int intValue = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

                // Chuyển 32 bit data thành 16 bit data
                int lower = intValue & 0xFFFF;       // Lower 16 bits
                int upper = (intValue >> 16) & 0xFFFF; // Upper 16 bits
                // Ghi data vào thanh ghi nhỏ hơn ( ví dụ DM22)
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, lowerWord, lower);
                // Ghi data vào thanh ghi lớn hơn ( ví dụ DM23)
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, upperWord, upper);
                // Thông báo khi ghi thành công
                MessageBox.Show($"Successfully wrote value.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Notify the user of an error
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Viết dữ liệu tốc độ vào thanh ghi DM:
        /// 1. Chuyển data từ float thành int 16 bit
        /// 2. Viết data vào 2 thanh ghi tương ứng (ví dụ DM22,DM23)
        /// Lưu ý: Với việc gửi data của tốc độ thì không cần thông báo gửi thành công
        /// </summary>
        private void WriteSpeedToPLC(string lowerWord, string upperWord, float value)
        {
            try
            {
                // Convert the float value to a 32-bit integer representation
                int intValue = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

                // Split the 32-bit integer into two 16-bit words
                int lower = intValue & 0xFFFF;       // Lower 16 bits
                int upper = (intValue >> 16) & 0xFFFF; // Upper 16 bits
                // Write the lower word to the lower address
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, lowerWord, lower);

                // Write the upper word to the upper address
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, upperWord, upper);
            }
            catch (Exception ex)
            {
                // Notify the user of an error
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa tất cả giá trị hiện tại và ghi 0 vào text box và lưu vào thanh ghi tương úng
        /// 1. Viết lại giá trị 0 vào text box
        /// 2. Viết giá trị 0 vào thanh ghi
        /// 3. Hiện thông báo ghi thành công hoặc không
        /// </summary>
        private void ClearAllLabel_MouseClick(object sender, MouseEventArgs e)
        {
            inputPos1.Text = "0.00";
            inputPos2.Text = "0.00";
            inputPos3.Text = "0.00";
            inputPos4.Text = "0.00";
            try
            {
                // Định nghĩa các giá trị cặp thanh ghi cần reset
                var addressPairs = new (string lowerWord, string upperWord)[]
                {
            ("22", "23"), // DM22, DM23
            ("30", "31"), // DM30, DM31
            ("38", "39"), // DM38, DM39
            ("46", "47")  // DM46, DM47
                };

                // Chạy 1 vòng lặp qua các cặp thanh ghi trên
                foreach (var (lowerWord, upperWord) in addressPairs)
                {
                    // Viết giá trị 0 vào thanh ghi có thứ tự nhỏ hơn
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, lowerWord, 0);

                    //  Viết giá trị 0 vào thanh ghi có thứ tự lớn hơn
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, upperWord, 0);
                }

                MessageBox.Show("All data has been reset.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to PLC: {ex.Message}");
            }
        }

        private void btnDelPos4_MouseClick(object sender, MouseEventArgs e)
        {
            inputPos4.Text = "0.00";
            WriteDataPos4();
        }

        private void btnDelPos3_MouseClick(object sender, MouseEventArgs e)
        {
            inputPos3.Text = "0.00";
            WriteDataPos3();
        }

        private void btnDelPos2_MouseClick(object sender, MouseEventArgs e)
        {
            inputPos2.Text = "0.00";
            WriteDataPos2();
        }

        private void btnDelPos1_MouseClick(object sender, MouseEventArgs e)
        {
            inputPos1.Text = "0.00";
            WriteDataPos1();
        }

        private void btnSavePos4_MouseClick(object sender, MouseEventArgs e)
        {
            WriteDataPos4();
        }

        private void btnSavePos3_MouseClick(object sender, MouseEventArgs e)
        {
            WriteDataPos3();
        }

        private void btnSavePos2_MouseClick(object sender, MouseEventArgs e)
        {
            WriteDataPos2();
        }

        private void btnSavePos1_MouseClick(object sender, MouseEventArgs e)
        {
            WriteDataPos1();
        }
        // Method
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToPLC();
            // Lấy giá trị của thẻ text box cho vị trí teaching ngay khi chạy chương trình
            UpdateTextBoxValues();
        }

        /// <summary>
        /// Cập nhập giá trị của thẻ text box khi chương trình đang chạy
        /// Tạo vòng lặp lặp qua các thẻ (textBoxMappings) và gọi ReadFloatFromPLC function trong mỗi lần lặp
        /// </summary>
        private void UpdateTextBoxValues()
        {
            try
            {
                // Chạy 1 vòng lặp qua các cặp thanh ghi trên
                var textBoxMappings = new (TextBox, string, string)[]
                {
        (inputPos1, "22", "23"),
        (inputPos2, "30", "31"),
        (inputPos3, "38", "39"),
        (inputPos4, "46", "47")
                };

                // Mỗi lần lặp sẽ in ra 1 giá trị của text box
                foreach (var (textBox, lowerAddress, upperAddress) in textBoxMappings)
                {
                    textBox.Text = ReadFloatFromPLC(lowerAddress, upperAddress).ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Data Failed: " + ex.Message, "Error",
     MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
     MessageBoxDefaultButton.Button1);
            }

        }

        /// <summary>
        /// Read float type value from PLC and return to string:
        /// 1. Read float type value 16 from PLC
        /// 2. Convert to float type 32 bit 
        /// 3. Return to a string
        /// </summary>
        private float ReadFloatFromPLC(string lowerAddress, string upperAddress)
        {
            try
            {
                int lowerWord = axDBCommManager1.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, lowerAddress);
                int upperWord = axDBCommManager1.ReadDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, upperAddress);
                return BitConverter.ToSingle(BitConverter.GetBytes((upperWord << 16) | lowerWord), 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Data Failed: " + ex.Message, "Error");
                return 0;
            }
        }

        private void ConnectToPLC()
        {
            // Connect to device
            try
            {
                axDBCommManager1.Connect();
                axDBTriggerManager1.Active = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed: " + ex.Message, "Error",
     MessageBoxButtons.RetryCancel, MessageBoxIcon.Error,
     MessageBoxDefaultButton.Button1);
            }
        }

        // Aplication UI
        #region Function Application UI

        #region Draw coordiante area 

        /// <summary>
        /// Vẽ khu vực hiển thị tọa độ
        /// 1. Đọc giá trị float 16 bit từ PLC
        /// 2. Chuyển về dang float 32 bit
        /// 3. Trả về string và in ra
        /// </summary>
        private void coorArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Định nghĩ function vẽ 
            int width = coorArea.Width; // Chiều rộng
            int height = coorArea.Height; // Chiều dài

            // Set up pens and brushes
            Pen axisPen = new Pen(textColor, 1); // Pen(Màu sắc, Độ dầy của đường tọa độ)
            Pen gridPen = new Pen(grayColor, 1);

            // Điểm origin (Chính giữa panel)
            Point origin = new Point(width / 2 - 1, height / 2 - 1);

            // Draw grid lines and labels
            int step = 15; // Kích thước 1 ô vuông nhỏ
            for (int i = 0; i < Math.Max(width, height); i += step)
            {
                // Vẽ các đường dọc
                if (i < width || i != width / 2)
                {
                    g.DrawLine(gridPen, i, 0, i, height-4);
                }
                // Vẽ các đường ngang
                if (i < height || i != height / 2)
                {
                    g.DrawLine(gridPen, 0, i, width-4, i);
                }
            }
            // Vẽ trục Y
            g.DrawLine(axisPen, origin.X, 10, origin.X, height - 10); // Y-axis

            // Không hiểu thì hỏi chủ code nhé, khó giải thích bằng chữ quá
            limitHome.Position = new Point(origin.X - 8, origin.Y - (int)(height * 0.45) - 15);
            limitNe.Position = new Point(origin.X - 8, origin.Y + (int)(height * 0.45) - 5);

            // Khoảng cách di chuyển được phép hiển thị bằng 95% chiều dài của panel tọa độ
            int distance = (int)(height * 0.95 - 5);
            // Khoảng cách di chuyển / tổng chiều dài
            int percent = (int)(distanceMove / distanceLimtit * 100);
            // Cài đặt giới hạn được phép di chuyển (cho việc hiển thị)
            if (percent < 1)
            {
                percent = 0;
            }
            else if (percent > 100){
                percent = 100;
            }

            // Không hiểu thì hỏi chủ code nhé, khó giải thích bằng chữ quá
            currentPos.Position = new Point(origin.X - 8, percent * distance / 100);
            currentCoor.Location = new Point(origin.X + 10, percent * distance / 100);
        }

        // Kiểm tra nếu thấy LED auto mode đang bật thì tắt và ngược lại
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            isButtonVisible = !isButtonVisible;
            currentPos.Visible = isButtonVisible;
        }

        #endregion

        #region Resize image of button
        // Just use dont ask
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }
        #endregion
        private void CustomSlider1_ValueChanged(object sender, EventArgs e)
        {
            float currentSpeed = ((customSlider1.Value / (float)100 * (maxSpeed - minSpeed)) + minSpeed); // Map to range of speed => không biết viết sao bằng tiếng Việt
            currentSpeedLabel.Text = $" {currentSpeed.ToString("F2")} mm/s"; //Hiển thị tốc độ hiện tại dưới định dạng .00 (F2)
            WriteSpeedToPLC("16", "17", currentSpeed); // Viết giá trị vào thanh ghi
        }

        #region Handle Mouse enter and mouse leave UI
        // Thay đổi màu nền của nút nhấn khi di chuột vào
        private void HandleMouseEnterButton(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = accentColor; // Set the color to accentColor or a predefined variable
            }
        }
        // Thay đổi màu nền của nút nhấn khi di chuột ra
        private void HandleMouseLeaveButton(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = bgBlack; // Set the color to black or a predefined variable
            }
        }
        #endregion

        #region Hanlde show popup pos 

        // Cài đặt thời gian chờ cho sự kiện MouseEnter và MouseLeave của nút hiện panel ẩn
        private void autoModeCard_Paint(object sender, PaintEventArgs e)
        {
            mouseLeaveTimerPos1.Start();
            mouseLeaveTimerPos2.Start();
            mouseLeaveTimerPos3.Start();
            mouseLeaveTimerPos4.Start();

        }


        #region Show Popup pos 1
        /// <summary>
        /// Handle mouse leave timer:
        /// TLogic của function là đợi xem khi trong khoảng thời gian là timerpos1 thì vị trí hiện tại của chuột có nằm trên nút save hay delete hay không
        /// Nếu không thì sẽ ẩn panel popupMore1, nếu có thì sẽ dừng bộ đếm timer
        /// </summary>
        private void MouseLeaveTimerPos1_Tick(object sender, EventArgs e)
        {
            // Nếu chuột không nằm trên btnDelPos1 và btnSavePos1 thì sẽ ẩn panel popupMore1
            if (!btnDelPos1.Bounds.Contains(PointToClient(Cursor.Position)) &&
                !btnSavePos1.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                popupMore1.Visible = false; // Hide both buttons
            }
            mouseLeaveTimerPos1.Stop(); // Stop the timer
        }

        /// <summary>
        /// Handle show popup position 1:
        /// Logic của function này là khi di chuộn vào nút more thì sẽ hiện panel popupMore1 và dừng bộ đếm timer
        /// </summary>
        private void btnMorePos1_MouseEnter(object sender, EventArgs e)
        {
            Point buttonLocation = btnMorePos1.PointToScreen(Point.Empty);
            Point panelLocation = this.PointToClient(new Point(buttonLocation.X - popupMore1.Width, buttonLocation.Y));
            popupMore1.Location = panelLocation;
            popupMore1.BringToFront(); // Ensure the popup panel is on top
            popupMore1.Visible = true;
            popupMore1.BackColor = accentColor;
            mouseLeaveTimerPos1.Stop();
        }
        private void btnShowPos1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos1.Start(); //khởi động bộ đếm timer để kiểm tra vị trí của chuột
        }
        /// <summary>
        /// Handle mouse enter event of save and delete button:
        /// Chức năng của function này là khi MouseEnter sẽ hiện panel popupMore1
        /// </summary>
        private void btnShowPos1_MouseEnter(object sender, EventArgs e)
        {
            mouseLeaveTimerPos1.Stop(); // Stop the timer
            popupMore1.Visible = true; // Show both buttons
        }

        private void btnMorePos1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos1.Start(); // Start the timer
        }
        #endregion

        #region Handle Button save pos 1
        private void btnSavePos1_MouseLeave(object sender, EventArgs e)
        {
            btnSavePos1.BorderColor = grayColor;

        }
        private void btnSavePos1_MouseEnter(object sender, EventArgs e)
        {
            btnSavePos1.BorderColor = accentColor;
        }
        #endregion

        #region Handle Button del pos 1
        private void btnDelPos1_MouseLeave(object sender, EventArgs e)
        {
            btnDelPos1.BorderColor = grayColor;
        }

        private void btnDelPos1_MouseEnter(object sender, EventArgs e)
        {
            btnDelPos1.BorderColor = accentColor;
        }

        #endregion
        private void popupMore1_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos1.Start();
            popupMore1.BackColor = bgBlack;
        }
        private void popupMore1_MouseEnter(object sender, EventArgs e)
        {
        }

        // Handle pop up pos 2
        #region Show Popup pos 2
        private void MouseLeaveTimerPos2_Tick(object sender, EventArgs e)
        {
            // If the mouse is no longer over either button, hide them
            if (!btnDelPos2.Bounds.Contains(PointToClient(Cursor.Position)) &&
                !btnSavePos2.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                HideButtonPos2(); // Hide both buttons
            }
            mouseLeaveTimerPos2.Stop(); // Stop the timer
        }
        private void HideButtonPos2()
        {
            popupMore2.Visible = false;
        }
        private void btnMorePos2_MouseEnter(object sender, EventArgs e)
        {
            Point buttonLocation = btnMorePos2.PointToScreen(Point.Empty);
            Point panelLocation = this.PointToClient(new Point(buttonLocation.X - popupMore2.Width, buttonLocation.Y));
            popupMore2.Location = panelLocation;
            popupMore2.BringToFront(); // Ensure the popup panel is on top
            //popupMore1.Visible = false;
            popupMore2.Visible = true;
            mouseLeaveTimerPos2.Stop();
            popupMore2.BackColor = accentColor;

            //popupMore3.Visible = false;
            //popupMore4.Visible = false;

        }
        private void btnShowPos2_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos2.Start();
            popupMore2.BackColor = accentColor;

        }
        private void btnShowPos2_MouseEnter(object sender, EventArgs e)
        {
            mouseLeaveTimerPos2.Stop(); // Stop the timer
            ShowButtonsPos2(); // Show both buttons

        }
        private void ShowButtonsPos2()
        {
            popupMore2.Visible = true;
            popupMore1.Visible = false;
        }
        private void btnMorePos2_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos2.Start();
            popupMore2.BackColor = accentColor;

        }
        #endregion

        #region Handle Button save pos 2
        private void btnSavePos2_MouseLeave(object sender, EventArgs e)
        {
            popupMore2.BackColor = bgBlack;


        }
        private void btnSavePos2_MouseEnter(object sender, EventArgs e)
        {
            btnSavePos2.BorderColor = accentColor;
        }
        #endregion

        #region Handle Button del pos 2
        private void btnDelPos2_MouseLeave(object sender, EventArgs e)
        {
            btnDelPos2.BorderColor = grayColor;
        }

        private void btnDelPos2_MouseEnter(object sender, EventArgs e)
        {
            btnDelPos2.BorderColor = accentColor;
        }

        #endregion

        // Handle pop up pos 3
        #region Show Popup pos 3
        private void MouseLeaveTimerPos3_Tick(object sender, EventArgs e)
        {
            // If the mouse is no longer over either button, hide them
            if (!btnDelPos3.Bounds.Contains(PointToClient(Cursor.Position)) &&
                !btnSavePos3.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                HideButtonPos3(); // Hide both buttons
            }
            mouseLeaveTimerPos3.Stop(); // Stop the timer
        }
        private void HideButtonPos3()
        {
            popupMore3.Visible = false;
        }
        private void btnMorePos3_MouseEnter(object sender, EventArgs e)
        {
            Point buttonLocation = btnMorePos3.PointToScreen(Point.Empty);
            Point panelLocation = this.PointToClient(new Point(buttonLocation.X - popupMore3.Width, buttonLocation.Y));
            popupMore3.Location = panelLocation;
            popupMore3.BringToFront(); // Ensure the popup panel is on top
            //popupMore1.Visible = false;
            //popupMore2.Visible = false;
            popupMore3.Visible = true;
            mouseLeaveTimerPos3.Stop();
            //popupMore4.Visible = false;

        }
        private void btnShowPos3_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos3.Start();
        }

        private void btnShowPos3_MouseEnter(object sender, EventArgs e)
        {
            mouseLeaveTimerPos3.Stop(); // Stop the timer
            ShowButtonsPos3(); // Show both buttons
        }
        private void ShowButtonsPos3()
        {
            popupMore3.Visible = true;
            popupMore1.Visible = false;
        }
        private void btnMorePos3_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos3.Stop();
        }
        #endregion

        #region Handle Button save pos 3
        private void btnSavePos3_MouseLeave(object sender, EventArgs e)
        {
            btnSavePos3.BorderColor = grayColor;

        }
        private void btnSavePos3_MouseEnter(object sender, EventArgs e)
        {
            btnSavePos3.BorderColor = accentColor;
        }
        #endregion

        #region Handle Button del pos 3
        private void btnDelPos3_MouseLeave(object sender, EventArgs e)
        {
            btnDelPos3.BorderColor = grayColor;
        }

        private void btnDelPos3_MouseEnter(object sender, EventArgs e)
        {
            btnDelPos3.BorderColor = accentColor;
        }

        #endregion

        // Handle pop up pos 4
        #region Show Popup pos 4
        private void MouseLeaveTimerPos4_Tick(object sender, EventArgs e)
        {
            // If the mouse is no longer over either button, hide them
            if (!btnDelPos4.Bounds.Contains(PointToClient(Cursor.Position)) &&
                !btnSavePos4.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                HideButtonPos4(); // Hide both buttons
            }
            mouseLeaveTimerPos4.Stop(); // Stop the timer
        }
        private void HideButtonPos4()
        {
            popupMore4.Visible = false;
        }
        private void btnMorePos4_MouseEnter(object sender, EventArgs e)
        {
            Point buttonLocation = btnMorePos4.PointToScreen(Point.Empty);
            Point panelLocation = this.PointToClient(new Point(buttonLocation.X - popupMore4.Width, buttonLocation.Y));
            popupMore4.Location = panelLocation;
            popupMore4.BringToFront(); // Ensure the popup panel is on top
            //popupMore1.Visible = false;
            //popupMore2.Visible = false;
            //popupMore3.Visible = false;
            popupMore4.Visible = true;
            mouseLeaveTimerPos4.Stop();

        }
        private void btnShowPos4_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos4.Start();
        }

        private void btnShowPos4_MouseEnter(object sender, EventArgs e)
        {
            mouseLeaveTimerPos4.Stop(); // Stop the timer
            ShowButtonsPos4(); // Show both buttons
        }
        private void ShowButtonsPos4()
        {
            popupMore4.Visible = true;
            popupMore1.Visible = false;
        }
        private void btnMorePos4_MouseLeave(object sender, EventArgs e)
        {
            mouseLeaveTimerPos4.Start();
        }
        #endregion

        #region Handle Button save pos 4
        private void btnSavePos4_MouseLeave(object sender, EventArgs e)
        {
            btnSavePos4.BorderColor = grayColor;

        }
        private void btnSavePos4_MouseEnter(object sender, EventArgs e)
        {
            btnSavePos4.BorderColor = accentColor;
        }
        #endregion

        #region Handle Button del pos 4
        private void btnDelPos4_MouseLeave(object sender, EventArgs e)
        {
            btnDelPos4.BorderColor = grayColor;
        }

        private void btnDelPos4_MouseEnter(object sender, EventArgs e)
        {
            btnDelPos4.BorderColor = accentColor;
        }

        #endregion
        #endregion

        #endregion

        #region Jog control Z
        // Control run clockwise direction


        #region Button Up High
        private void btnUpHigh_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "102", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpHigh_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "102", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Button Up
        private void btnUp_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "103", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "103", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        // Control run Home

        #region Button Home
        private void btnHome_Click(object sender, EventArgs e)
        {
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "100", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHome_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "100", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        // Control run counter clockwise direction
        #region Button Down
        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "105", 1);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error writing to device: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "105", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Down High
        private void btnDownHigh_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "104", 1);
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownHigh_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "104", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        #region Auto Run
        #region Position 1
        private void btnRunPos1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                WriteDataPos1();
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "603", 1);
                blinkTimer.Start(); // delay 300ms to make sure MR 603 on
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 1);
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error writing to device: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnRunPos1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "603", 0);
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to device: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Position 2
        private void btnRunPos2_Click(object sender, EventArgs e)
        {

        }

        private void btnRunPos2_MouseDown(object sender, MouseEventArgs e)
        {
            WriteDataPos2();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "604", 1);
            blinkTimer.Start();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 1);
        }
        private void btnRunPos2_MouseUp(object sender, MouseEventArgs e)
        {
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "604", 0);
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 0);
        }
        #endregion

        #region Position 3
        private void btnRunPos3_Click(object sender, EventArgs e)
        {


        }
        private void btnRunPos3_MouseDown(object sender, MouseEventArgs e)
        {
            WriteDataPos3();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "605", 1);
            blinkTimer.Start();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 1);

        }

        private void btnRunPos3_MouseUp(object sender, MouseEventArgs e)
        {
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "605", 0);
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 0);

        }
        #endregion

        #region Position 4
        private void btnRunPos4_Click(object sender, EventArgs e)
        {


        }
        private void btnRunPos4_MouseDown(object sender, MouseEventArgs e)
        {
            WriteDataPos4();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "606", 1);
            blinkTimer.Start();
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 1);
        }

        private void btnRunPos4_MouseUp(object sender, MouseEventArgs e)
        {
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "606", 0);
            axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "611", 0);

        }

        #endregion
        #endregion

        #region Read Data
        private void axDBDeviceManager1_BeforeRead(object sender, EventArgs e)
        {
            try
            {
                int CR8404 = axDBDeviceManager1.Devices[1].ValueRead;

                // Print current coordinate
                // Data get from CM8830 memory is word type
                ushort CM8830 = ushort.Parse(axDBDeviceManager1.Devices[2].ValueRead.ToString());
                ushort CM8831 = ushort.Parse(axDBDeviceManager1.Devices[3].ValueRead.ToString());
                //Combining Two 16-bit Integers
                float combined2 = (CM8831 << 16) | CM8830;
                string currentCoordinate = (combined2 / (pulsesPerRevolution / threadPitch)).ToString("F2");
                currentCoor.Text = $" {currentCoordinate} mm";
                //AutoFillData(currentCoordinate);
                distanceMove = (combined2 / -1200);
            }
            catch (Exception)
            {

                MessageBox.Show("Read Data Failed", "Error");
            }


        }

        // Write data from input text box to CM register
        private void WriteDataPos1()
        {
            try
            {
                float value;
                if (string.IsNullOrEmpty(inputPos1.Text))
                {
                    value = 0.00f;
                }
                else
                {
                    value = float.Parse(inputPos1.Text);
                }
                WritePosToPLC("22", "23", value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to DM22: {ex.Message}");
            }

        }
        private void WriteDataPos2()
        {
            try
            {
                float value;
                if (string.IsNullOrEmpty(inputPos2.Text))
                {
                    value = 0.00f;
                }
                else
                {
                    value = float.Parse(inputPos2.Text);
                }
                WritePosToPLC("30", "31", value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to DM30: {ex.Message}");
            }
        }
        private void WriteDataPos3()
        {
            try
            {

                float value;
                if (string.IsNullOrEmpty(inputPos3.Text))
                {
                    value = 0.00f;
                }
                else
                {
                    value = float.Parse(inputPos3.Text);
                }
                WritePosToPLC("38", "39", value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to DM38: {ex.Message}");
            }
        }
        private void WriteDataPos4()
        {
            try
            {
                float value;
                if (string.IsNullOrEmpty(inputPos4.Text))
                {
                    value = 0.00f;
                }
                else
                {
                    value = float.Parse(inputPos4.Text);
                }
                WritePosToPLC("46", "47", value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to DM46: {ex.Message}");
            }
        }

        #endregion

    }
}
