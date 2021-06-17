using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ADFSProxyCertRenew.config
{
    public partial class frm_main : Form
    {
        private ADFSProxyController aDFSProxyController = new ADFSProxyController();
        private Configuration Configuration { get; set; } = Configuration.Load();
        private ACMECertificate selectedaCMECertificate { get; set; }
        private List<AdfsProxy.WebApplicationProxyApplication> webApplicationProxyApplications { get; set; }
        public frm_main()
        {
            this.InitializeComponent();
            this.webApplicationProxyApplications = this.aDFSProxyController.GetWebApplicationProxyApplications();
            foreach (ACMECertificate certificate in this.Configuration.ACMECertificates)
            {
                this.List_Certificates.Items.Add(certificate);
            }
            this.Txt_adminmail.Text = this.Configuration.RegestrationMailAdress;
            this.Txt_workingDir.Text = this.Configuration.WorkingDir;
            if (this.Configuration.AcmeServer != null)
            {
                foreach (object listentry in this.List_ACMEServer.Items)
                {
                    if (listentry.ToString().ToLower() == this.Configuration.AcmeServer.ToLower())
                    {
                        this.List_ACMEServer.SelectedIndex = this.List_ACMEServer.Items.IndexOf(listentry);
                    }
                }
            }
        }

        private void SelectedAcmeCertificateChanged()
        {
            if (this.selectedaCMECertificate != null)
            {
                this.lbl_actualExiresOn.Text = this.selectedaCMECertificate.ActualCertificateExpiresOn.ToShortDateString() + " " + this.selectedaCMECertificate.ActualCertificateExpiresOn.ToLongTimeString();
                this.Lbl_ActualThumbprint.Text = this.selectedaCMECertificate.ActualCertificateThumbprint;

                this.Cb_AutoRenew.Checked = this.selectedaCMECertificate.AutoRenew;
                this.Cb_BindToAdfsProxySSL.Checked = this.selectedaCMECertificate.BindToWebApplicationProxySslCertificate;
                this.Txt_commonName.Text = this.selectedaCMECertificate.CommonName;
                this.Txt_country.Text = this.selectedaCMECertificate.Country;
                this.Txt_description.Text = this.selectedaCMECertificate.Description;
                this.Txt_eMail.Text = this.selectedaCMECertificate.Email;
                this.Txt_givenName.Text = this.selectedaCMECertificate.GivenName;
                this.Txt_initals.Text = this.selectedaCMECertificate.Initials;
                this.Txt_locality.Text = this.selectedaCMECertificate.Locality;
                this.Txt_Organization.Text = this.selectedaCMECertificate.Organization;
                this.Txt_organizationUinit.Text = this.selectedaCMECertificate.OrganizationUnit;
                this.Txt_PFXPwd.Text = this.selectedaCMECertificate.PFXPassword;
                this.txt_State.Text = this.selectedaCMECertificate.StateOrProvince;
                this.Txt_surname.Text = this.selectedaCMECertificate.Surname;
                this.Txt_title.Text = this.selectedaCMECertificate.Title;

                this.List_adfsbinding.Items.Clear();
                foreach (AdfsProxy.WebApplicationProxyApplication wapa in this.webApplicationProxyApplications)
                {
                    ListViewItem lvi = new ListViewItem
                    {
                        Tag = wapa,
                        Text = wapa.Name
                    };
                    lvi.SubItems.Add(wapa.ExternalUrl);
                    lvi.SubItems.Add(wapa.ExternalCertificateThumbprint);
                    lvi.SubItems.Add(wapa.ID.ToString());
                    if (this.selectedaCMECertificate.ADFSWebApplicationProxyBindings.Contains(wapa.ID))
                    {
                        lvi.BackColor = System.Drawing.Color.AliceBlue;
                    }

                    this.List_adfsbinding.Items.Add(lvi);
                }
                this.groupBox2.Enabled = true;
                this.groupBox3.Enabled = true;
            }
            else
            {
                this.groupBox2.Enabled = false;
                this.groupBox3.Enabled = false;
            }
        }

        private void Btn_add_Certificate_Click(object sender, System.EventArgs e)
        {
            ACMECertificate aCMECertificate = new ACMECertificate()
            {
                CommonName = "new"
            };
            this.Configuration.ACMECertificates.Add(aCMECertificate);
            this.List_Certificates.Items.Add(aCMECertificate);
        }

        private void List_Certificates_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.List_Certificates.SelectedItem != null)
            {
                this.selectedaCMECertificate = this.List_Certificates.SelectedItem as ACMECertificate;
                this.SelectedAcmeCertificateChanged();
            }
        }

        private void Btn_bindToCertificate_Click(object sender, System.EventArgs e)
        {
            if (this.List_adfsbinding.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in this.List_adfsbinding.SelectedItems)
                {
                    lvi.BackColor = System.Drawing.Color.AliceBlue;
                    this.selectedaCMECertificate.ADFSWebApplicationProxyBindings.Add(((AdfsProxy.WebApplicationProxyApplication)lvi.Tag).ID);
                }
            }
        }

        private void Txt_commonName_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.CommonName = this.Txt_commonName.Text;
            }
        }

        private void Txt_PFXPwd_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.PFXPassword = this.Txt_PFXPwd.Text;
            }
        }

        private void Txt_country_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Country = this.Txt_country.Text;
            }
        }

        private void Txt_description_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Description = this.Txt_description.Text;
            }
        }

        private void Txt_eMail_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Email = this.Txt_eMail.Text;
            }
        }

        private void Txt_givenName_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.GivenName = this.Txt_givenName.Text;
            }
        }

        private void Txt_initals_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Initials = this.Txt_initals.Text;
            }
        }

        private void Txt_locality_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Locality = this.Txt_locality.Text;
            }
        }

        private void Txt_Organization_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Organization = this.Txt_Organization.Text;
            }
        }

        private void Txt_organizationUinit_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.OrganizationUnit = this.Txt_organizationUinit.Text;
            }
        }

        private void txt_State_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.StateOrProvince = this.txt_State.Text;
            }
        }

        private void Txt_surname_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Surname = this.Txt_surname.Text;
            }
        }

        private void Txt_title_TextChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.Title = this.Txt_title.Text;
            }
        }

        private void Cb_BindToAdfsProxySSL_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.BindToWebApplicationProxySslCertificate = this.Cb_BindToAdfsProxySSL.Checked;
            }
        }

        private void Cb_AutoRenew_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.selectedaCMECertificate != null)
            {
                this.selectedaCMECertificate.AutoRenew = this.Cb_AutoRenew.Checked;
            }
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            foreach (ACMECertificate certificate in this.Configuration.ACMECertificates)
            {
                certificate.AlternativeNames.Clear();
                foreach (Guid wapaGuid in certificate.ADFSWebApplicationProxyBindings)
                {
                    AdfsProxy.WebApplicationProxyApplication webApplicationProxyApplication = this.webApplicationProxyApplications.FirstOrDefault(x => x.ID == wapaGuid);
                    if (webApplicationProxyApplication != null)
                    {
                        Uri uri = new Uri(webApplicationProxyApplication.ExternalUrl);
                        if (!certificate.AlternativeNames.Contains(uri.DnsSafeHost))
                        {
                            certificate.AlternativeNames.Add(uri.DnsSafeHost);
                        }
                    }
                }
            }

            ACMEController aCMEController = new ACMEController(this.Configuration.AcmeServer, this.Configuration.RegestrationMailAdress, this.Configuration.WorkingDir);
            if (aCMEController.NeedToBeRegisterd)
            {
                if (MessageBox.Show("The Acme Client Need to bee Registerd", "ACME Cert Renew", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    aCMEController.RegisterACMEClient();
                }
            }
            this.Configuration.Save();
            MessageBox.Show("Configuration is Saved");
        }

        private void txt_adminmail_TextChanged(object sender, EventArgs e)
        {
            this.Configuration.RegestrationMailAdress = this.Txt_adminmail.Text;
        }

        private void List_ACMEServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Configuration.AcmeServer = this.List_ACMEServer.SelectedItem?.ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.List_adfsbinding.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in this.List_adfsbinding.SelectedItems)
                {
                    lvi.BackColor = this.List_adfsbinding.BackColor;
                    this.selectedaCMECertificate.ADFSWebApplicationProxyBindings.Remove(((AdfsProxy.WebApplicationProxyApplication)lvi.Tag).ID);
                }
            }
        }

        private void btn_remove_Certificate_Click(object sender, EventArgs e)
        {
            if (this.List_Certificates.SelectedItem != null)
            {
                this.selectedaCMECertificate = null;
                this.SelectedAcmeCertificateChanged();
                this.Configuration.ACMECertificates.Remove(this.List_Certificates.SelectedItem as ACMECertificate);
                this.List_Certificates.Items.Remove(this.List_Certificates.SelectedItem);
            }
            
        }

        private void Txt_workingDir_TextChanged(object sender, EventArgs e)
        {
            this.Configuration.WorkingDir = this.Txt_workingDir.Text;
        }
    }
}
