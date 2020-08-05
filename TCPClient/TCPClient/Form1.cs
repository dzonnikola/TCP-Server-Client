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


namespace TCPClient
{
    public partial class Form1 : Form
    {

        TcpClient tcpClient;
        byte[] rX;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ipa;
            int nPort;

            try
            {
                if(string.IsNullOrEmpty(tbServerIp.Text) || string.IsNullOrEmpty(tbServerPort.Text))
                    return;
                if(!IPAddress.TryParse(tbServerIp.Text, out ipa))
                {
                    MessageBox.Show("Unesite ip adresu.");
                    return;
                }
                if(!int.TryParse(tbServerPort.Text, out nPort))
                {
                    nPort = 23000;
                }

                tcpClient = new TcpClient();

                tcpClient.BeginConnect(ipa, nPort, onCompleteConnect, tcpClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onCompleteConnect(IAsyncResult ar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)ar.AsyncState;
                tcpc.EndConnect(ar);
                rX = new byte[512];
                tcpc.GetStream().BeginRead(rX, 0, rX.Length, onCompleteReadFromServerStream, tcpc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onCompleteReadFromServerStream(IAsyncResult ar)
        {
            TcpClient tcpc;
            int nCountBytesReceivedFromServer;
            string strReceived;

            try
            {
                tcpc = (TcpClient)ar.AsyncState;
                nCountBytesReceivedFromServer = tcpc.GetStream().EndRead(ar);

                if(nCountBytesReceivedFromServer == 0)
                {
                    MessageBox.Show("Konekcija prekinuta.");
                    return;
                }

                strReceived = Encoding.ASCII.GetString(rX, 0, nCountBytesReceivedFromServer);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] tx;

            if (string.IsNullOrEmpty(tbMessage.Text)) return;
            try
            {
                tx = Encoding.ASCII.GetBytes(tbMessage.Text);
                if(tcpClient != null)
                {
                    if (tcpClient.Client.Connected)
                    {
                        tcpClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, tcpClient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                tbMessage.Clear();
            }
        }

        private void onCompleteWriteToServer(IAsyncResult ar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)ar.AsyncState;
                tcpc.GetStream().EndWrite(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
