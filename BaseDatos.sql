USE [Pry_Practico_BP]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Clienteid] [int] NOT NULL,
	[Contraseña] [nvarchar](50) NULL,
	[Estado] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[ClienteId] [int] NULL,
	[NumCuenta] [bigint] NOT NULL,
	[TipoCuenta] [nvarchar](50) NULL,
	[SaldoInicial] [numeric](18, 2) NULL,
	[Estado] [nvarchar](50) NULL,
	[IdCuenta] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMov] [int] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[Fecha] [date] NULL,
	[TipoMovimiento] [nvarchar](50) NULL,
	[Valor] [numeric](18, 2) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[SaldoIni] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMov] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[idParam] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Valor] [numeric](18, 2) NULL,
	[Estado] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
	[Genero] [nvarchar](50) NULL,
	[Edad] [int] NULL,
	[Identificación] [nvarchar](13) NOT NULL,
	[Dirección] [nvarchar](300) NULL,
	[Teléfono] [nvarchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificación] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Consulta_Clientes]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Consulta_Clientes]  
@Accion varchar(250),  
@Id int  
as  
begin  
declare @idAUx int  
  
   if  @Accion = 'General'  
   begin  
        
   select P.Id,P.Nombre,P.Genero,P.Edad,P.Identificación,P.Dirección,P.Teléfono,C.Contraseña,C.Estado   
   from Persona P, Cliente C where P.Id=C.Clienteid  
  
   end  
  else if  @Accion = 'Individual'  
  begin        
        select P.Id,P.Nombre,P.Genero,P.Edad,P.Identificación,P.Dirección,P.Teléfono,C.Contraseña,C.Estado from Persona P, Cliente C where P.Id=C.Clienteid  
          and Id=@Id  
  end  
  else  
  begin  
     delete from Persona where Id = @Id  
     delete from Cliente where Clienteid=@Id  
  end  
  
end  
  
GO
/****** Object:  StoredProcedure [dbo].[Usp_Consulta_Cuentas]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Consulta_Cuentas]    
@Accion varchar(250),    
@Id int    
as    
begin    
   
    
   if  @Accion = 'General'    
   begin    
          
   select C.NumCuenta,C.TipoCuenta,C.SaldoInicial,C.Estado,P.Nombre
   from Cuentas C,Persona P where P.Id=C.Clienteid    
    
   end    
  else if  @Accion = 'Individual'    
  begin          
        select C.NumCuenta,C.TipoCuenta,C.SaldoInicial,C.Estado,P.Nombre
        from Cuentas C,Persona P where P.Id=C.Clienteid  and C.NumCuenta=@Id
  end    
  else    
  begin    
  
      delete from Cuentas where NumCuenta=@Id    
  end    
    
end    
GO
/****** Object:  StoredProcedure [dbo].[Usp_Consulta_Mov]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Consulta_Mov]      
@Accion varchar(250),      
@IdCiente int,
@FecIni date,
@FecFin date   
as      
begin      
     
      
   if  @Accion = 'General'      
   begin      
            
	   select format (M.fecha,'dd/MM/yyyy') as fecha,P.Nombre , C.NumCuenta,C.TipoCuenta,M.SaldoIni as SaldoInicial,C.Estado,
	   case when TipoMovimiento='Débito' then '-' + convert (varchar(20),M.valor)
	     when  TipoMovimiento='crédito' then '+' + convert (varchar(20),M.valor)  end Movimiento,M.saldo
	   from Cuentas C,Persona P, movimientos M where P.Id=C.Clienteid and C.IdCuenta=   M.IdCuenta 
	   order by P.Nombre
      
   end      
  else if  @Accion = 'Individual'      
  begin            
          select format (M.fecha,'dd/MM/yyyy') as fecha,P.Nombre , C.NumCuenta,C.TipoCuenta,M.SaldoIni,C.Estado,
	   case when TipoMovimiento='Débito' then '-' + convert (varchar(20),M.valor)
	     when  TipoMovimiento='crédito' then '+' + convert (varchar(20),M.valor)  end Movimiento,M.saldo
	   from Cuentas C,Persona P, movimientos M where P.Id=C.Clienteid and C.IdCuenta=   M.IdCuenta 
	   and C.Clienteid=@IdCiente and M.fecha between  @FecFin  and @FecFin 
	   order by P.Nombre
  end         
      
end 
GO
/****** Object:  StoredProcedure [dbo].[Usp_Inser_Movimientos]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Inser_Movimientos]     
@Accion varchar(250),     
@IdCuenta int,      
@TipoMov varchar(10),   
@Valor varchar(50)             
as      
begin      
    declare @Saldo numeric(18,2),@Limte numeric(18,2),@CupoDiario numeric(18,2),@SaldoIni numeric(18,2) 

	select @Limte=valor from parametros where idParam=1 and estado=0

   if  @Accion = 'Insertar'      
   begin   
       
	  select @Saldo=SaldoInicial from cuentas where IdCuenta=@IdCuenta

	 select @CupoDiario= SUM( Valor) from movimientos where IdCuenta=@IdCuenta and year(fecha)=year(GETDATE())
	 and month(fecha)=month(GETDATE()) and  day(fecha)=day(GETDATE())

	 set @CupoDiario = @CupoDiario + @Valor
	
	   if @Saldo=0 and @TipoMov = 'débito'
	   begin
	       select 'Saldo no disponible' RespuestaTrx
		   return;
	   end
	   else if @Valor > @Saldo and @TipoMov = 'débito'
	   begin
	       select 'Saldo no disponible' RespuestaTrx
		   return;
	   end
	   else if @CupoDiario > @Limte and @TipoMov = 'débito'
	   begin
	        select 'Cupo diario Excedido' RespuestaTrx
		    return;
	   end

	  set @SaldoIni=@Saldo

	  if @TipoMov = 'crédito' 
	   begin
	      set @Saldo = @Saldo + @Valor
	   end
	   else
	   begin
	      set @Saldo = @Saldo - @Valor
	   end
             
	   insert into Movimientos values (@IdCuenta,GETDATE(),@TipoMov,@Valor,@Saldo,@SaldoIni) 

	   update cuentas set SaldoInicial=@Saldo where  IdCuenta=@IdCuenta

	   select 'OK' RespuestaTrx
	              
   end      
 
      
end 
GO
/****** Object:  StoredProcedure [dbo].[Usp_Inser_Update_Acciones_Clientes]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Inser_Update_Acciones_Clientes]   
@Accion varchar(250),   
@Id int,    
@Nombre varchar(500) ,    
@Genero varchar(50),    
@Edad int ,    
@Identificación varchar(13),    
@Dirección varchar(300),    
@Teléfono varchar(13),    
@Contraseña varchar(100),    
@Estado varchar(100)    
as    
begin    
    
   if  @Accion = 'Insertar'    
   begin    
          
      insert into  Persona values (@Nombre,@Genero,@Edad,@Identificación,@Dirección,@Teléfono)    
    
     select top 1 @id=Id from Persona order by Id desc    
    
     insert into Cliente values (@id,@Contraseña,@Estado)    
      
    
   end    
  Else    
  begin    
    
      update Persona set Nombre = @Nombre,Genero=@Genero,Edad=@Edad,Dirección=@Dirección,Teléfono=@Teléfono,Identificación=@Identificación WHERE     
       Id=@id  
    
     
      UPDATE Cliente SET Contraseña=@Contraseña ,Estado=@Estado WHERE Clienteid=@id    
    
  end    
    
end 
GO
/****** Object:  StoredProcedure [dbo].[Usp_Inser_Update_Cuentas]    Script Date: 26/12/2022 11:16:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usp_Inser_Update_Cuentas]     
@Accion varchar(250),     
@IdCliente int,      
@NumCuenta bigint,      
@TipoCuenta varchar(50),      
@SaldoInicial int ,           
@Estado varchar(100)      
as      
begin      
      
   if  @Accion = 'Insertar'      
   begin         
	   insert into Cuentas values (@IdCliente,@NumCuenta,@TipoCuenta,@SaldoInicial,@Estado)            
   end      
  Else      
  begin      

    update Cuentas set TipoCuenta=@TipoCuenta, SaldoInicial=@SaldoInicial,Estado=@Estado where NumCuenta=@NumCuenta
      
  end      
      
end 
GO
