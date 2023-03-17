using System;
using System.IO;
class Program {
 //paciente
  public struct paciente{
    public int cod;
    public string nome;
    public string end;
    public int telefone;   
    
    public paciente (int Cod, string Nome, string End, int Telefone){
      cod = Cod;
      nome = Nome;
      end = End;
      telefone = Telefone;
    }

    public void Imprimir(){
      Console.WriteLine($"{cod} - {nome} - {end} - {telefone}");
    }

    public override string ToString(){
      return ($"{cod};{nome};{end};{telefone}");
    }

    public void cadastrar(int codigo){
      cod = codigo;
      Console.WriteLine("Digite o nome do paciente");
      nome = Console.ReadLine();
      Console.WriteLine("Digite o endereco do paciente");
      end = Console.ReadLine();
      Console.WriteLine("Digite o telefone do paciente");
      telefone = int.Parse(Console.ReadLine());
    }
  }
 //medico
  public struct medico{
    public int cod;
    public string nome;
    public int telefone;

    public medico (int Cod, string Nome, int Telefone){
      cod = Cod;
      nome = Nome;
      telefone = Telefone;
    }
    public void Imprimir(){
      Console.WriteLine($"{cod} - {nome} - {telefone}");
    }

    public override string ToString(){
      return ($"{cod};{nome};{telefone}");
    }
    public void cadastrar(int codigo){
      cod = codigo;
      Console.WriteLine("Digite o nome");
      nome = Console.ReadLine();
      Console.WriteLine("Digite o telefone ");
      telefone = int.Parse(Console.ReadLine());
    }
  }
//consulta
  public struct consulta{
    public int nConsulta;
    public int dSemana;
    public double hora;
    public int codM;
    public int codP;
  
    public consulta (int codigo, int dia, double horas, int codm, int codp ){
      nConsulta = codigo;
      dSemana = dia;
      hora = horas;
      codM = codm;
      codP = codp;
    }
    public void Imprimir(){
      Console.WriteLine($"{nConsulta} - {dSemana} - {hora} - {codM} - {codP}");
    }

    public override string ToString(){
      return ($"{nConsulta};{dSemana};{hora};{codM};{codP}");
    }
    
    
     public void cadastrar(int codigo){
      nConsulta = codigo;
      dSemana = DiaS();
      Console.WriteLine("Digite o horario ");
      hora = double.Parse(Console.ReadLine());
       
       Console.WriteLine("Digite o codigo do medico");
       codM = int.Parse(Console.ReadLine());
       
        
       Console.WriteLine("Digite o codigo do paciente");
       codP = int.Parse(Console.ReadLine());
 
       
    }
    
    
  }
  //marcacao
  public struct marcarConsulta{

    public int MAX;
    public int NP;
    public int NM;
    public int NC;
    public int SequenciaP;
    public int SequenciaM;
    public int SequenciaC;
    public paciente [] PACIENTES;
    public medico [] MEDICOS;
    public consulta [] CONSULTA;

    public marcarConsulta(int quantidade){
      MAX = quantidade;
      NP = 0;
      NM = 0;
      NC = 0;
      SequenciaP = 1;
      SequenciaM = 1;
      SequenciaC = 1;
      PACIENTES = new paciente[MAX];
      MEDICOS = new medico[MAX];
      CONSULTA = new consulta [MAX*2];
    }

    //PACIENTE

    public void ImprimirP(){
      Console.WriteLine("\n\nPACIENTES:\n");
      for(int i=0; i<NP;i++){
        PACIENTES[i].Imprimir();
      }
    }

    public void CadastrarP(){
      if(NP == MAX){
        Console.WriteLine("Limite maximo");
      }else{
        PACIENTES[NP++].cadastrar(SequenciaP++);
      }
    }

    public int PesquisarP(int codigo){
      for(int i=0; i<NP;i++){
        if(codigo == PACIENTES[i].cod){
          return i;
        }
      }
      return -1;
    }

    public void PesquisarP(){
      Console.WriteLine("Digite o codigo do paciente");
      int codigo = int.Parse(Console.ReadLine());
      int i = PesquisarP(codigo);
      if(i== -1){
        Console.WriteLine("Paciente invalido");
      }else{
        PACIENTES[i].Imprimir();
      }
      
    }
    
    //MEDICO
    public void ImprimirM(){
      Console.WriteLine("\n\nMEDICOS:\n");
      for(int i=0; i<NM;i++){
        MEDICOS[i].Imprimir();
      }
    }

    public void CadastrarM(){
      if(NM == MAX){
        Console.WriteLine("Limite maximo");
      }else{
        MEDICOS[NM++].cadastrar(SequenciaM++);
      }
    }

    public int PesquisarM(int codigo){
      for(int i=0; i<NM;i++){
        if(codigo == MEDICOS[i].cod){
          return i;
        }
      }
      return -1;
    }

    public void PesquisarM(){
      Console.WriteLine("Digite o codigo do medico");
      int codigo = int.Parse(Console.ReadLine());
      int i = PesquisarM(codigo);
      if(i== -1){
        Console.WriteLine("Consulta invalida");
      }else{
        MEDICOS[i].Imprimir();
      }
      
    }


    
    //Consulta
 public string getNomeMedico(int cod){
      string nome="";
     for(int i=0; i<NM; i++){
       if(MEDICOS[i].cod == cod ){
         nome = MEDICOS[i].nome;
       }
     }
      return nome;
    }
    
    public void consultaDIA(){
      int dia = DiaS();
      
      string nomemedico="";
      for(int i=0; i< NC; i++){
        if(CONSULTA[i].dSemana == dia){
          nomemedico = getNomeMedico(CONSULTA[i].codM);
         
          double horaC = CONSULTA[i].hora;
          int numero = CONSULTA[i].nConsulta;
          int cod = CONSULTA[i].codP;
          
                 Console.WriteLine($"O medico {nomemedico} tem a consulta:  ");        
          Console.WriteLine($"consultas: {horaC} o identificador da consulta {numero}, o codigo do paciente {cod}");
        }
        
      }
    }
    
    

    public void CadastrarC(){
      if(NC == MAX*2){
        Console.WriteLine("Limite maximo");
      }else{
        int contador=0;
        do{
        CONSULTA[NC].cadastrar(SequenciaC);
          
          
         contador= numConsultas(CONSULTA[NC].codM,CONSULTA[NC].dSemana);
          if(contador > 1){
            Console.WriteLine("Medico com duas consulta no dia, escolha outro");
          }
          
        }while(contador > 1);
        NC++; SequenciaC++;
      }
    }

    public int numConsultas(int medico, int dia){
      int cont=0;
      for(int i=0; i< NC; i++){
        if(CONSULTA[i].dSemana == dia && CONSULTA[i].codM == medico){
          cont++;
        }
      }
    return cont;  
    }

    public void iConDia(){
        Console.WriteLine("Digite o codigo do medico: ");
        int codigo = int.Parse(Console.ReadLine());
        int dia = DiaS();
       int contador=0;
        for(int i=0; i< NC; i++){
          if(CONSULTA[i].dSemana == dia && CONSULTA[i].codM == codigo){
            contador++;
          }
        }
      Console.WriteLine($"O medico tem {contador}");
      
    }

    public int PesquisarC(int codigo){
      for(int i=0; i<NC;i++){
        if(codigo == CONSULTA[i].nConsulta){
          return i;
        }
      }
      return -1;
    }

    public void PesquisarC(){
      Console.WriteLine("Digite o codigo da consulta");
      int codigo = int.Parse(Console.ReadLine());
      int i = PesquisarC(codigo);
      if(i== -1){
        Console.WriteLine("Consulta invalida");
      }else{
        CONSULTA[i].Imprimir();
      }
      
    }

    
 
    //gravacoes
    public void GravarArquivo(){
      StreamWriter sw = new StreamWriter("arquivo.txt");

      sw.WriteLine(NP);
      for(int i=0; i<NP;i++){
        sw.WriteLine(PACIENTES[i].ToString());
      }
      
      sw.WriteLine(NM);
      for(int i=0; i<NM;i++){
        sw.WriteLine(MEDICOS[i].ToString());
      }

      sw.WriteLine(NC);
      for(int i=0; i<NC;i++){
        sw.WriteLine(CONSULTA[i].ToString());
      }
      sw.Close();
    }

    public void LerArquivo(){
      try{
        StreamReader sr = new StreamReader("arquivo.txt");

         NP = int.Parse(sr.ReadLine());
        for(int i=0; i<NP; i++){
          string [] paciente = sr.ReadLine().Split(";");
          PACIENTES[i].cod = int.Parse(paciente[0]);
          PACIENTES[i].nome = (paciente[1]);
          PACIENTES[i].end = (paciente[2]);
          PACIENTES[i].telefone = int.Parse(paciente[3]);
        }
        SequenciaP = PACIENTES[NP-1].cod+1;
        
        NM = int.Parse(sr.ReadLine());
        for(int i=0; i<NM; i++){
          string [] medico = sr.ReadLine().Split(";");
          MEDICOS[i].cod = int.Parse(medico[0]);
          MEDICOS[i].nome = (medico[1]);
          MEDICOS[i].telefone = int.Parse(medico[2]);
        }
        SequenciaM = MEDICOS[NM-1].cod+1;

        
        NC = int.Parse(sr.ReadLine());
        for(int i=0; i<NC; i++){
          string[] consulta = sr.ReadLine().Split(";");
          CONSULTA[i].nConsulta = int.Parse(consulta[0]);
          CONSULTA[i].dSemana = int.Parse(consulta[1]);
          CONSULTA[i].hora = double.Parse(consulta[2]);
          CONSULTA[i].codM = int.Parse(consulta[3]);
          CONSULTA[i].codP = int.Parse(consulta[4]);
        }
        SequenciaC = CONSULTA[NC-1].nConsulta+1;

        sr.Close();
        
      }catch{}
      
    }
 
  }

  
  static int DiaS(){
    int d=0;
    do{
    Console.WriteLine("SELECIONE A OPCAO");
    Console.WriteLine("2 - Segunda");
    Console.WriteLine("3 - Terca");
    Console.WriteLine("4 - Quarta");
    Console.WriteLine("5 - Quinta");
    Console.WriteLine("6 - Sexta");
    Console.WriteLine("Qual sera o dia");
    d = int.Parse(Console.ReadLine());
    }while(d <2 || d >6 );
    return d;
  }

  
  static int Menu(){

    Console.WriteLine(" ==> CONSULTORIO SUA DOENCA NOSSA FELICIDADE <==");
    Console.WriteLine("1 - MARCAR CONSULTA");
    Console.WriteLine("2 - CADASTRAR PACIENTE");
    Console.WriteLine("3 - CADASTRAR MEDICO");
    Console.WriteLine("4 - VER CONSULTAS DO MEDICO");
    Console.WriteLine("5 - VER CONSULTA DO DIA");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite sua opcao: ");
    int opcao = int.Parse(Console.ReadLine());

    return opcao;
  }

 

  
  public static void Main (string[] args) {

    marcarConsulta mC = new marcarConsulta(10);
    mC.LerArquivo();
    int op=0;//opcao
    

    do{
     op = Menu();
      switch(op){
        case 1:
         mC.CadastrarC();
        break;
        case 2:
         mC.CadastrarP();
        break;
        case 3:
         mC.CadastrarM();
        break;

        case 4:
          mC.iConDia();
          break;
        case 5:
          mC.consultaDIA();
          
          break;
        case 0:
          mC.GravarArquivo();
          Console.WriteLine("\n\nEncerrando o programa...\n\n");
          break;
        default: Console.WriteLine("\n\nOpção Invalida!!!\n\n");
          break;  
      }
    }while(op != 0);
   
  
  }
}