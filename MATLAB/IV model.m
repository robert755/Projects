load("CiceuLab8.mat")

%plot uri initiale
figure;
plot(u)
title("U")
figure;
plot(vel)
title("Vel")

%esantioane pentru id si val
u_id=u(50:350);
y_id=vel(50:350);

u_val=u(450:end);
y_val=vel(450:end);

%na nb initiale;
na=10;
nb=10;
phi=[]; %matrice goala
phi_val=[]; %matrice goala
tetha=[]; %vector gol

identif=iddata(y_id',u_id,t(2)-t(1));
arx1=arx(identif,[na,nb,1]);
y_idhat=lsim(u_id,arx1);

%identificarea sistemului ARX
N=length(y_id);

%prima parte a matricei cu y
for i=1:N 
for j=1:na
    if i-j>0
    phi(i,j)=-y_idhat(i-j);
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
tetha=phi\y_idhat;

%Calculam A si B pentru modelul IV
A_IV = [];
A_IV(1) = 1;
A_IV(2:na+1) = tetha(1:na);
B_IV= [];
B_IV(1) = 0;
B_IV(2:nb+1)=tetha(na+1:end);

%Creem modelul IV
iv_model = idpoly(A_IV,B_IV,1,1,1,0,0.01);
val = iddata(y_val', u_val, t(2)-t(1));

%simulam modelul IV
y_valhat=lsim(u_val,iv_model);

%plot urile finale
figure;
plot(y_valhat)
hold on
plot(y_val)
title('y.valhat vs y.val')
