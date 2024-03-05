load("lab6_3.mat")
%grafice initiale
figure;
plot(id)
title("Identificarea initiala")

figure;
plot(val)
title("Validarea initiala")

%date initiale
u_id=id.u;
y_id=id.y;
u_val=val.u;
y_val=val.y;

%na nb initiale;
na=9;
nb=9;
phi=[]; %matrice goala
phi_val=[]; %matrice goala
tetha=[]; %vector gol


%identificarea sistemului ARX
N=length(u_id );
%prima parte a matricei cu y
for i=1:N 
for j=1:na
    if i-j>0
    phi(i,j)=-y_id(i-j);
    elseif i-j<0
    phi(i,j)=0;
    end
  end
end
%a doua jumatate a matricei cu u
for i=1:N
for j=na+1:na+nb
    if i-(j-na)>0
    phi(i,j)=u_id(i-(j-na));
    elseif i-(j-na)<0
    phi(i,j)=0;
    end
   end
end

%Calcularea lui tetha
tetha= phi\ y_id; 
Nval=length(u_val);

%y pentru identificare
y_id1=phi*tetha;

%validarea arx prin prezicere (la fel matrice ca la id)
for i=1:Nval
for j=1:na
    if i-j>0
    phi_val(i,j)=-y_val(i-j);
    elseif i-j<0
    phi_val(i,j)=0;
    end
   end
end
for i=1:Nval
for j=na+1:na+nb
    if i-(j-na)>0
    phi_val(i,j)=u_val(i-(j-na));
    elseif i-(j-na)<0
    phi_val(i,j)=0;
    end
   end
end
%y_hat prezis
y_hat=phi_val*tetha;

%validare prin simulare
ysim=zeros(Nval,1);
for i=1:Nval
    y1=0; %suma pentru toate y urile 
    y2=0; %suma pentru toate u urile
for j=1:na
    if i-j>0
    y1=y1-tetha(j)*ysim(i-j);
   end
end
for j=1:nb
    if i-j>0
    y2=y2+tetha(na+j)*u_val(i-j);
    end
    end
    ysim(i)=y1+y2;
end

% Eroare identificare
e1 = y_id - y_id1;
MSE1=1/N*sum(e1.^2)

% Eroare validare prezicere
e2 = y_val - y_hat;
MSE2=1/Nval*sum(e2.^2)

% Eroare validare simulare
e3 = y_val - ysim;
MSE3=1/Nval*sum(e3.^2)

model=arx(val,[na,nb,1]);
figure; %compararea validarii cu modelul arx cu formula
compare(model,val)

figure;
plot(y_id1)
hold on
plot(y_id)
title ('Identificare model ARX')

figure;
plot(y_hat)
hold on
plot(y_val)
title("Validare model ARX prin prezicere");

figure;
plot(ysim)
hold on
plot(y_val) 
title("Validare model ARX prin simulare");

%fprintf("eroarea de identificare este :  %.5f\n",MSE1)
%fprintf("eroarea de validare prin prezicere este :  %.5f\n",MSE2)
%fprintf("eroarea prin simuare este  :  %.5f\n",MSE3)
