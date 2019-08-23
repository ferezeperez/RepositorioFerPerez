using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;

namespace frmBuscandoAD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnTraerAD_Click(object sender, EventArgs e)
        {
            LLenardgv();
        }

        private void btnADconMembrecias_Click(object sender, EventArgs e)
        {
            LLenardgvUsuariosConMembrecias();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem.ToString() == "ControlC")
            {
                LlenardgvControlC();

            }
            else
            {
                if (cboBusqueda.SelectedItem.ToString() == "ControlSemanal")
                {
                    LlenardgvControlSemanal();

                }
                else
                {
                    if (cboBusqueda.SelectedItem.ToString() == "BusquedaPorUPN")
                    {
                        llenardgvGetADPorMail();
                    }
                    else
                    {
                        if (cboBusqueda.SelectedItem.ToString() == "ConsultaAD")
                        {
                            llenardgvGetConsultaEnAD();
                        }
                        else
                        {
                            LlenardgvLog();
                        }
                    }
                }

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string NombreArchivoExportado = "Reporte_FrmBuscandoAD";
            string outCsvFile = string.Format(@"\\fscentralar\homecentral$\EC0664\Reportes\{0}.csv", NombreArchivoExportado + DateTime.Now.ToString("_yyyyMMdd HHmms"));
            var stream = File.CreateText(outCsvFile);
            stream.Close();
            writeCSV(dgvUsuarios, outCsvFile);
        }

        public List<Usuario> GetADUsers()
        {
            List<Usuario> rst = new List<Usuario>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 20000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("employeeid");
            adSearcher.PropertiesToLoad.Add("employeenumber");
            adSearcher.PropertiesToLoad.Add("mail");
            adSearcher.PropertiesToLoad.Add("displayname");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            Usuario item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        item = new Usuario();

                        item.UserName = (String)result.Properties["samaccountname"][0];

                        if (result.Properties.Contains("employeeid"))
                        {
                            item.DNI = (String)result.Properties["employeeid"][0];
                        }
                        else
                        {
                            item.DNI = "-";
                        }

                        if (result.Properties.Contains("employeenumber"))
                        {
                            item.Legajo = (String)result.Properties["employeenumber"][0];
                        }
                        else
                        {
                            item.Legajo = "-";
                        }

                        if (result.Properties.Contains("displayname"))
                        {
                            item.DisplayName = (String)result.Properties["displayname"][0];
                        }
                        else
                        {
                            item.DisplayName = "-";
                        }

                        if (result.Properties.Contains("mail"))
                        {
                            item.Email = (String)result.Properties["mail"][0];
                        }
                        else
                        {
                            item.Email = "-";
                        }

                        rst.Add(item);
                    }
                }
                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;
        }

        public List<UsuarioConsultaAD> GetConsultaAD(string usuario)
        {
            List<UsuarioConsultaAD> rst = new List<UsuarioConsultaAD>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 10000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(samaccountname=" + usuario + "))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("Employeeid");
            adSearcher.PropertiesToLoad.Add("Employeenumber");
            adSearcher.PropertiesToLoad.Add("mail");
            adSearcher.PropertiesToLoad.Add("displayname");
            adSearcher.PropertiesToLoad.Add("userAccountControl");
            adSearcher.PropertiesToLoad.Add("title");
            adSearcher.PropertiesToLoad.Add("department");
            adSearcher.PropertiesToLoad.Add("departmentnumber");
            adSearcher.PropertiesToLoad.Add("company");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            UsuarioConsultaAD item;
                if (iResult != null)
                {
                    for (int counter = 0; counter < iResult.Count; counter++)
                    {
                        result = iResult[counter];
                        if (result.Properties.Contains("samaccountname"))
                        {
                            item = new UsuarioConsultaAD();

                            item.ID = (String)result.Properties["samaccountname"][0];

                            if (result.Properties.Contains("Employeeid"))
                            {
                                item.DNI = (String)result.Properties["Employeeid"][0];
                            }
                            else
                            {
                                item.DNI = "-";
                            }

                            if (result.Properties.Contains("Employeenumber"))
                            {
                                item.Legajo = (String)result.Properties["Employeenumber"][0];
                            }
                            else
                            {
                                item.Legajo = "-";
                            }

                            if (result.Properties.Contains("mail"))
                            {
                                item.Correo = (String)result.Properties["mail"][0];
                            }
                            else
                            {
                                item.Correo = "-";
                            }

                            if (result.Properties.Contains("displayname"))
                            {
                                item.NombreCompleto = (String)result.Properties["displayname"][0];
                            }
                            else
                            {
                                item.NombreCompleto = "-";
                            }

                            if (result.Properties.Contains("userAccountControl"))
                            {
                                if (Convert.ToString(result.Properties["userAccountControl"][0]) == "512" | Convert.ToString(result.Properties["userAccountControl"][0]) == "544" |
                                Convert.ToString(result.Properties["userAccountControl"][0]) == "66048" | Convert.ToString(result.Properties["userAccountControl"][0]) == "66080" |
                                Convert.ToString(result.Properties["userAccountControl"][0]) == "262656" | Convert.ToString(result.Properties["userAccountControl"][0]) == "262688" |
                                Convert.ToString(result.Properties["userAccountControl"][0]) == "328192" | Convert.ToString(result.Properties["userAccountControl"][0]) == "328224")
                                {
                                    item.Habilitado = "Habilitado";
                                }
                                else
                                {
                                    item.Habilitado = "Deshabilitado";
                                }
                            }

                            if (result.Properties.Contains("title"))
                            {
                                item.Puesto = (String)result.Properties["title"][0];
                            }
                            else
                            {
                                item.Puesto = "-";
                            }

                            if (result.Properties.Contains("department"))
                            {
                                item.Sector = (String)result.Properties["department"][0];
                            }
                            else
                            {
                                item.Sector = "-";
                            }

                            if (result.Properties.Contains("departmentnumber"))
                            {
                                item.CentroDeCosto = (String)result.Properties["departmentnumber"][0];
                            }
                            else
                            {
                                item.CentroDeCosto = "-";
                            }

                            if (result.Properties.Contains("company"))
                            {
                                item.LugarDeTrabajo = (String)result.Properties["company"][0];
                            }
                            else
                            {
                                item.LugarDeTrabajo = "-";
                            }

                            rst.Add(item);
                        }
                    }

                    label1.Text = iResult.Count.ToString();
                }
                adSearcher.Dispose();
                adSearchRoot.Dispose();
                return rst;

        }

        public List<UsuarioMail> GetADPorMail(string usuario)
        {
            List<UsuarioMail> rst = new List<UsuarioMail>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 10000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(userPrincipalName=" + usuario + "))";
            adSearcher.PropertiesToLoad.Add("userPrincipalName");
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("Employeeid");
            adSearcher.PropertiesToLoad.Add("Employeenumber");
            adSearcher.PropertiesToLoad.Add("displayname");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            UsuarioMail item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("userPrincipalName"))
                    {
                        item = new UsuarioMail();

                        item.UPN = (String)result.Properties["userPrincipalName"][0];

                        if (result.Properties.Contains("samaccountname"))
                        {
                            item.ID = (String)result.Properties["samaccountname"][0];
                        }
                        else
                        {
                            item.ID = "-";
                        }

                        if (result.Properties.Contains("Employeeid"))
                        {
                            item.DNI = (String)result.Properties["Employeeid"][0];
                        }
                        else
                        {
                            item.DNI = "-";
                        }

                        if (result.Properties.Contains("Employeenumber"))
                        {
                            item.Legajo = (String)result.Properties["Employeenumber"][0];
                        }
                        else
                        {
                            item.Legajo = "-";
                        }

                        if (result.Properties.Contains("displayname"))
                        {
                            item.NombreCompleto = (String)result.Properties["displayname"][0];
                        }
                        else
                        {
                            item.NombreCompleto = "-";
                        }
                        rst.Add(item);
                    }
                }

                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;

        }

        public List<ControlC> GetADControlC(string usuario)
        {
            List<ControlC> rst = new List<ControlC>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 10000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(sAMAccountName=" + usuario + "))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("adspath");
            adSearcher.PropertiesToLoad.Add("accountexpires");
            adSearcher.PropertiesToLoad.Add("userAccountControl");
            adSearcher.PropertiesToLoad.Add("streetaddress");
            adSearcher.PropertiesToLoad.Add("l");
            adSearcher.PropertiesToLoad.Add("st");
            //adSearcher.PropertiesToLoad.Add("mobile");
            //adSearcher.PropertiesToLoad.Add("displayname");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            ControlC item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        item = new ControlC();

                        item.ID = (String)result.Properties["samaccountname"][0];

                        if (result.Properties.Contains("adspath"))
                        {
                            item.OU = (String)result.Properties["adspath"][0];
                        }
                        else
                        {
                            item.OU = "-";
                        }

                        try
                        {
                            if (result.Properties.Contains("accountexpires"))
                            {
                                var accountExpires = Convert.ToInt64(result.Properties["accountexpires"][0]);

                                var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(accountExpires)).ToShortDateString();

                                item.FechaExpiracion = Convert.ToString(dt);
                                if (item.FechaExpiracion == "31/12/1600")
                                {
                                    item.FechaExpiracion = "Nunca";
                                }

                            }
                        }
                        catch (Exception)
                        {

                            item.FechaExpiracion = "NUNCA";
                        }

                        if (result.Properties.Contains("userAccountControl"))
                        {
                            if (Convert.ToString(result.Properties["userAccountControl"][0]) == "512" | Convert.ToString(result.Properties["userAccountControl"][0]) == "544" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "66048" | Convert.ToString(result.Properties["userAccountControl"][0]) == "66080" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "262656" | Convert.ToString(result.Properties["userAccountControl"][0]) == "262688" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "328192" | Convert.ToString(result.Properties["userAccountControl"][0]) == "328224")
                            {
                                item.Habilitado = "Habilitado";
                            }
                            else
                            {
                                item.Habilitado = "Deshabilitado";
                            }
                        }

                        if (result.Properties.Contains("streetaddress"))
                        {
                            item.AGPBaja = (String)result.Properties["streetaddress"][0];
                        }
                        else
                        {
                            item.AGPBaja = "-";
                        }

                        if (result.Properties.Contains("l"))
                        {
                            item.City = (String)result.Properties["l"][0];
                        }
                        else
                        {
                            item.City = "-";
                        }

                        if (result.Properties.Contains("st"))
                        {
                            item.OUvieja = (String)result.Properties["st"][0];
                        }
                        else
                        {
                            item.OUvieja = "-";
                        }

                        rst.Add(item);
                    }
                }

                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;

        }

        public List<ControlSemanal> GetADControlSemanal(string usuario)
        {
            List<ControlSemanal> rst = new List<ControlSemanal>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 10000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(sAMAccountName=" + usuario + "))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("adspath");
            adSearcher.PropertiesToLoad.Add("accountexpires");
            adSearcher.PropertiesToLoad.Add("userAccountControl");
            adSearcher.PropertiesToLoad.Add("streetaddress");
            adSearcher.PropertiesToLoad.Add("l");
            adSearcher.PropertiesToLoad.Add("displayname");
            adSearcher.PropertiesToLoad.Add("Employeeid");
            adSearcher.PropertiesToLoad.Add("Employeenumber");
            adSearcher.PropertiesToLoad.Add("whencreated");
            adSearcher.PropertiesToLoad.Add("wwwhomepage");
            //adSearcher.PropertiesToLoad.Add("mobile");
            //adSearcher.PropertiesToLoad.Add("displayname");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            ControlSemanal item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        item = new ControlSemanal();

                        item.ID = (String)result.Properties["samaccountname"][0];

                        if (result.Properties.Contains("adspath"))
                        {
                            item.OU = (String)result.Properties["adspath"][0];
                        }
                        else
                        {
                            item.OU = "-";
                        }

                        try
                        {
                            if (result.Properties.Contains("accountexpires"))
                            {
                                var accountExpires = Convert.ToInt64(result.Properties["accountexpires"][0]);

                                var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(accountExpires)).ToShortDateString();

                                item.FechaExpiracion = Convert.ToString(dt);
                                if (item.FechaExpiracion == "31/12/1600")
                                {
                                    item.FechaExpiracion = "Nunca";
                                }

                            }
                        }
                        catch (Exception)
                        {
                            item.FechaExpiracion = "NUNCA";
                        }
               
                        if (result.Properties.Contains("userAccountControl"))
                        {
                            if (Convert.ToString(result.Properties["userAccountControl"][0]) == "512" | Convert.ToString(result.Properties["userAccountControl"][0]) == "544" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "66048" | Convert.ToString(result.Properties["userAccountControl"][0]) == "66080" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "262656" | Convert.ToString(result.Properties["userAccountControl"][0]) == "262688" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "328192" | Convert.ToString(result.Properties["userAccountControl"][0]) == "328224")
                            {
                                item.Habilitado = "Habilitado";
                            }
                            else
                            {
                                item.Habilitado = "Deshabilitado";
                            }
                        }

                        if (result.Properties.Contains("streetaddress"))
                        {
                            item.AGPBaja = (String)result.Properties["streetaddress"][0];
                        }
                        else
                        {
                            item.AGPBaja = "-";
                        }

                        if (result.Properties.Contains("l"))
                        {
                            item.City = (String)result.Properties["l"][0];
                        }
                        else
                        {
                            item.City = "-";
                        }

                        if (result.Properties.Contains("displayname"))
                        {
                            item.NombreCompleto = (String)result.Properties["displayname"][0];
                        }
                        else
                        {
                            item.NombreCompleto = "-";
                        }

                        if (result.Properties.Contains("Employeeid"))
                        {
                            item.DNI = (String)result.Properties["Employeeid"][0];
                        }
                        else
                        {
                            item.DNI = "-";
                        }

                        if (result.Properties.Contains("Employeenumber"))
                        {
                            item.Legajo = (String)result.Properties["Employeenumber"][0];
                        }
                        else
                        {
                            item.Legajo = "-";
                        }

                        if (result.Properties.Contains("whencreated"))
                        {

                            item.Creacion = Convert.ToDateTime(result.Properties["whencreated"][0]);
                        }
                        else
                        {
                        }

                        if (result.Properties.Contains("wwwhomepage"))
                        {
                            item.AgpAlta = (String)result.Properties["wwwhomepage"][0];
                        }
                        else
                        {
                            item.AgpAlta = "-";
                        }

                        rst.Add(item);
                    }
                }

                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;

        }

        public List<Log> GetLog(string usuario)
        {
            List<Log> rst = new List<Log>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 10000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(sAMAccountName=" + usuario + "))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("accountexpires");
            adSearcher.PropertiesToLoad.Add("userAccountControl");
            adSearcher.PropertiesToLoad.Add("whencreated");
            adSearcher.PropertiesToLoad.Add("whenchanged");
            adSearcher.PropertiesToLoad.Add("lastlogon");
            adSearcher.PropertiesToLoad.Add("lastlogontimestamp");
            adSearcher.PropertiesToLoad.Add("pwdlastset");
            //adSearcher.PropertiesToLoad.Add("mobile");
            //adSearcher.PropertiesToLoad.Add("displayname");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            Log item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        item = new Log();

                        item.ID = (String)result.Properties["samaccountname"][0];

                        try
                        {
                            if (result.Properties.Contains("accountexpires"))
                            {
                                var accountExpires = Convert.ToInt64(result.Properties["accountexpires"][0]);

                                var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(accountExpires)).ToShortDateString();

                                item.FechaExpiracion = Convert.ToString(dt);
                                if (item.FechaExpiracion == "31/12/1600")
                                {
                                    item.FechaExpiracion = "Nunca";
                                }

                            }
                        }
                        catch (Exception)
                        {
                            item.FechaExpiracion = "NUNCA";
                        }

                        if (result.Properties.Contains("userAccountControl"))
                        {
                            if (Convert.ToString(result.Properties["userAccountControl"][0]) == "512" | Convert.ToString(result.Properties["userAccountControl"][0]) == "544" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "66048" | Convert.ToString(result.Properties["userAccountControl"][0]) == "66080" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "262656" | Convert.ToString(result.Properties["userAccountControl"][0]) == "262688" |
                            Convert.ToString(result.Properties["userAccountControl"][0]) == "328192" | Convert.ToString(result.Properties["userAccountControl"][0]) == "328224")
                            {
                                item.Habilitado = "Habilitado";
                            }
                            else
                            {
                                item.Habilitado = "Deshabilitado";
                            }
                        }

                        if (result.Properties.Contains("whencreated"))
                        {

                            item.Creacion = Convert.ToDateTime(result.Properties["whencreated"][0]);
                        }
                        else
                        {
                        }

                        if (result.Properties.Contains("whenchanged"))
                        {

                            item.Modificado = Convert.ToDateTime(result.Properties["whenchanged"][0]);
                        }
                        else
                        {
                        }

                        if (result.Properties.Contains("lastlogon"))
                        {
                            var lastlogon = Convert.ToInt64(result.Properties["lastlogon"][0]);

                            var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(lastlogon)).ToShortDateString();

                            item.UltimoAcceso = Convert.ToString(dt);

                        }
                        else
                        {
                            item.UltimoAcceso = "No logueo";
                        }

                        if (result.Properties.Contains("lastlogontimestamp"))
                        {
                            var lastlogon = Convert.ToInt64(result.Properties["lastlogontimestamp"][0]);

                            var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(lastlogon)).ToShortDateString();

                            item.UltimoAccesoMarcado = Convert.ToString(dt);

                        }
                        else
                        {
                            item.UltimoAccesoMarcado = "No logueo";
                        }

                        if (result.Properties.Contains("pwdlastset"))
                        {
                            var pwdlastset = Convert.ToInt64(result.Properties["pwdlastset"][0]);

                            var dt = new DateTime(1600, 12, 31, 0, 0, 0, DateTimeKind.Local).AddTicks(Convert.ToInt64(pwdlastset)).ToShortDateString();

                            item.UltimoCambioPassword = Convert.ToString(dt);

                        }
                        else
                        {
                            item.UltimoCambioPassword = "No logueo";
                        }



                        rst.Add(item);
                    }
                }

                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;

        }

        public List<UsuarioADcompleto> GetADUsersConMembrecias()
        {
            List<UsuarioADcompleto> rst = new List<UsuarioADcompleto>();

            string DomainPath = "LDAP://DC=CENCOSUD,DC=corp";
            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);
            adSearcher.SizeLimit = 0;
            adSearcher.PageSize = 20000;
            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
            adSearcher.PropertiesToLoad.Add("samaccountname");
            adSearcher.PropertiesToLoad.Add("adspath");
            adSearcher.PropertiesToLoad.Add("memberof");
            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            UsuarioADcompleto item;
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains("samaccountname"))
                    {
                        item = new UsuarioADcompleto();

                        item.UserName = (String)result.Properties["samaccountname"][0];

                        if (result.Properties.Contains("adspath"))
                        {
                            item.OU = (String)result.Properties["adspath"][0];
                        }
                        else
                        {
                            item.OU = "-";
                        }

                        if (result.Properties.Contains("memberof"))
                        {
                            string membrecias = string.Empty;

                            foreach (object memberOf in result.Properties["memberOf"])
                            {
                                membrecias += memberOf.ToString();
                            }

                            item.Membrecias = membrecias;
                        }
                        else
                        {
                            item.Membrecias = "-";
                        }

                        rst.Add(item);
                    }
                }
                label1.Text = iResult.Count.ToString();
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;
        }

        void LLenardgv()
        {
            dgvUsuarios.DataSource = GetADUsers();
        }

        void LLenardgvUsuariosConMembrecias()
        {
            dgvUsuarios.DataSource = GetADUsersConMembrecias();
        }

        void llenardgvGetConsultaEnAD()
        {
            List<UsuarioConsultaAD> rst = new List<UsuarioConsultaAD>();

            int Contador = 0;

            foreach (var linea in txtUsuarios.Lines)
            {
                Contador++;
                if (linea == "")
                {

                }
                else
                {
                    rst.AddRange(GetConsultaAD(linea));
                }
            }

            label1.Text = Convert.ToString(Contador);
            dgvUsuarios.DataSource = rst;
        }

        void llenardgvGetADPorMail()
        {
            List<UsuarioMail> rst = new List<UsuarioMail>();

            int Contador = 0;

            foreach (var linea in txtUsuarios.Lines)
            {
                Contador++;
                if (linea == "")
                {
                }
                else
                {
                    rst.AddRange(GetADPorMail(linea));
                }
            }

            label1.Text = Convert.ToString(Contador);
            dgvUsuarios.DataSource = rst;
        }

        void LlenardgvControlC()
        {
            List<ControlC> rst = new List<ControlC>();
            int Contador = 0;

            foreach (var linea in txtUsuarios.Lines)
            {
                Contador++;
                if (linea=="")
                {

                }
                else
                {
                    rst.AddRange(GetADControlC(linea));
                }
            }

            label1.Text = Convert.ToString(Contador);
            dgvUsuarios.DataSource = rst;
        }

        void LlenardgvControlSemanal()
        {
            List<ControlSemanal> rst = new List<ControlSemanal>();
            int Contador = 0;
            
            foreach (var linea in txtUsuarios.Lines)
            {
                Contador++;
                if (linea == "")
                {

                }
                else
                {
                    rst.AddRange(GetADControlSemanal(linea));
                }
            }
            label1.Text = Convert.ToString(Contador);
            dgvUsuarios.DataSource = rst;
        }

        void LlenardgvLog()
        {
            List<Log> rst = new List<Log>();
            int contador = 0;

            foreach (var linea in txtUsuarios.Lines)
            {
                contador++;
                if (linea == "")
                {

                }
                else
                {
                    rst.AddRange(GetLog(linea));
                }
            }
            label1.Text = Convert.ToString(contador);
            dgvUsuarios.DataSource = rst;
        }

        public void writeCSV(DataGridView dgvUsuarios, string outputFile)
        {
            //test to see if the DataGridView has any rows}

            DataGridViewRow dr = new DataGridViewRow();

            if (dgvUsuarios.RowCount > 0)
            {
                string value = "";

                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= dgvUsuarios.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(dgvUsuarios.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= dgvUsuarios.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = dgvUsuarios.Rows[j];

                    for (int i = 0; i <= dgvUsuarios.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
                MessageBox.Show("Archivo Exportado correctamente.");

            }
        }

        
    }
}
