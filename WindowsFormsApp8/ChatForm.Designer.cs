using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Timers;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp8
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanelChat = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonAddChat = new System.Windows.Forms.Button();
            this.labelChatName = new System.Windows.Forms.Label();
            this.buttonChangeName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelChat
            // 
            this.flowLayoutPanelChat.AutoScroll = true;
            this.flowLayoutPanelChat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelChat.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelChat.Name = "flowLayoutPanelChat";
            this.flowLayoutPanelChat.Size = new System.Drawing.Size(188, 326);
            this.flowLayoutPanelChat.TabIndex = 0;
            this.flowLayoutPanelChat.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelChat_Paint);
            // 
            // flowLayoutPanelMessages
            // 
            this.flowLayoutPanelMessages.AutoScroll = true;
            this.flowLayoutPanelMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelMessages.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelMessages.Location = new System.Drawing.Point(188, 33);
            this.flowLayoutPanelMessages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelMessages.Name = "flowLayoutPanelMessages";
            this.flowLayoutPanelMessages.Size = new System.Drawing.Size(414, 293);
            this.flowLayoutPanelMessages.TabIndex = 1;
            this.flowLayoutPanelMessages.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMessages_Paint);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Location = new System.Drawing.Point(191, 329);
            this.textBoxMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(300, 32);
            this.textBoxMessage.TabIndex = 0;
            // 
            // ButtonSend
            // 
            this.ButtonSend.BackColor = System.Drawing.Color.Gold;
            this.ButtonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonSend.Location = new System.Drawing.Point(496, 329);
            this.ButtonSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(98, 32);
            this.ButtonSend.TabIndex = 2;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = false;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click_1);
            // 
            // ButtonAddChat
            // 
            this.ButtonAddChat.BackColor = System.Drawing.Color.Gold;
            this.ButtonAddChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddChat.ForeColor = System.Drawing.Color.Black;
            this.ButtonAddChat.Location = new System.Drawing.Point(2, 329);
            this.ButtonAddChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonAddChat.Name = "ButtonAddChat";
            this.ButtonAddChat.Size = new System.Drawing.Size(184, 32);
            this.ButtonAddChat.TabIndex = 3;
            this.ButtonAddChat.Text = "Add Chat";
            this.ButtonAddChat.UseVisualStyleBackColor = false;
            this.ButtonAddChat.Click += new System.EventHandler(this.ButtonAddChat_Click);
            // 
            // labelChatName
            // 
            this.labelChatName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChatName.BackColor = System.Drawing.Color.Gold;
            this.labelChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChatName.ForeColor = System.Drawing.Color.Black;
            this.labelChatName.Location = new System.Drawing.Point(191, 4);
            this.labelChatName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChatName.Name = "labelChatName";
            this.labelChatName.Size = new System.Drawing.Size(379, 24);
            this.labelChatName.TabIndex = 4;
            // 
            // buttonChangeName
            // 
            this.buttonChangeName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonChangeName.Image = ((System.Drawing.Image)(resources.GetObject("buttonChangeName.Image")));
            this.buttonChangeName.Location = new System.Drawing.Point(572, 2);
            this.buttonChangeName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonChangeName.Name = "buttonChangeName";
            this.buttonChangeName.Size = new System.Drawing.Size(26, 28);
            this.buttonChangeName.TabIndex = 5;
            this.buttonChangeName.UseVisualStyleBackColor = true;
            this.buttonChangeName.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonChangeName);
            this.Controls.Add(this.labelChatName);
            this.Controls.Add(this.ButtonAddChat);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.flowLayoutPanelMessages);
            this.Controls.Add(this.flowLayoutPanelChat);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMessages;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonAddChat;
        private System.Windows.Forms.Label labelChatName;
        private System.Windows.Forms.Button buttonChangeName;
    }
}

