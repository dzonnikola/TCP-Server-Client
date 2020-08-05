using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TCPServer01
{
    public partial class Form1 : Form
    {
        TcpListener mTCPListener;
        TcpClient mTCPClient;
        byte[] mRx;

        public Form1()
        {
            InitializeComponent();
        }

        private void tbStartListening_Click(object sender, EventArgs e)
        {
            IPAddress ipaddr;
            int nPort;

            if(!int.TryParse(tbPort.Text, out nPort))
            {
                nPort = 23000;
            }
            if(!IPAddress.TryParse(tbIPAdress.Text, out ipaddr))
            {
                ipaddr = IPAddress.Any;
            }

            mTCPListener = new TcpListener(ipaddr, nPort);

            mTCPListener.Start();

            mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);

        }

        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {
                mTCPClient = tcpl.EndAcceptTcpClient(iar);

                printLine("Klijent konektovan.");

                mRx = new byte[512];

                mTCPClient.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, mTCPClient);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void onCompleteReadFromTCPClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                nCountReadBytes = tcpc.GetStream().EndRead(iar);

                if(nCountReadBytes == 0)
                {
                    MessageBox.Show("Klijent diskonektovan.");
                    return;
                }

                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);
                printLine(strRecv);

                mRx = new byte[512];

                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, tcpc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void printLine(string _print)
        {
            tbConsoleOutput.Invoke(new Action<string>(doInvoke), _print);
        }

        public void doInvoke(string _print)
        {
            tbConsoleOutput.Text = _print + Environment.NewLine + tbConsoleOutput.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] tx = new byte[512];

            if (string.IsNullOrEmpty(tbSendClient.Text)) return;

            try
            {
                if(mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {
                        tx = Encoding.ASCII.GetBytes(tbSendClient.Text);
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbSendClient.Clear();
            }
        }

        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndRead(iar);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
