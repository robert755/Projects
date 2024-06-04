load("proj_fit_14.mat")
id.X; %date identificare
id.Y; %date identificare
val.X; %date validare
val.Y;  %date validare
%mesh urile sunt folosite pentru crearea graficelor initiale
%tridimensionale
figure; 
mesh(id.X{1},id.X{2},id.Y)
mesh(val.X{1},val.X{2},val.Y) 
title("Grafic Initial")

phi = [];
phi_val=[];
theta=[];
n=30; %gradul polinomului 30
MSE1=zeros(1,n);
MSE2=zeros(1,n);

for n=1:30 %luam n de la 1 la 30 pentru a vedea evolutia 
%matricea phi de identificare
N=length(id.X{1}); %nr de puncte din setul de identificare
il = 1; %indexul liniei
for i = 1:N 
for j = 1:N
   ic = 1; %indexul coloanei
for m = 0:n %putere
for w = 0:n %putere
   if m + w <= n %puterile adunate trebuie sa fie mai mici sau egale cu gradul polinomului
    if m == 0 && w == 0 %conditie pt prima coloana
       phi(il, ic) = 1; % Prima coloană este întotdeauna 1
     else
    phi(il, ic) = id.X{1}(i)^m * id.X{2}(j)^w; % Calculează valorile pentru celelalte coloane
    end
    ic = ic + 1; %trecem la urmatoarea coloana
    end
    end
    end
    il = il + 1; %trecem la urmatoarea linie
    end
end
% matricea phi de validare se face la fel ca cea de identificare
M=length(val.X{1}); %nr de puncte din setul de validare
il_val = 1;
for i= 1:M
for j= 1:M
   ic_val = 1;
for m= 0:n
for w = 0:n
   if m+w <= n
 if m== 0 && w == 0
     phi_val(il_val, ic_val) = 1; % Prima coloană este întotdeauna 1
    else
   phi_val(il_val, ic_val) = val.X{1}(i)^m* val.X{2}(j)^w; % Calculează valorile pentru celelalte coloane
    end
    ic_val = ic_val + 1;
    end
    end
    end
il_val = il_val + 1;
end
end

% Calcularea vectorului de parametri theta
Y_id=reshape(id.Y,N*N,1);
theta=phi\Y_id;

% Estimarea ieșirilor aproximative pentru setul de identificare
y_aprox_id=phi*theta;
y_aprox1_id=reshape(y_aprox_id,N,N);

% Estimarea ieșirilor aproximative pentru setul de validare
Y_val=reshape(val.Y,M*M,1);
y_aprox_val=phi_val*theta;
y_aprox1_val=reshape(y_aprox_val,M,M);

% Afișarea graficelor doar pentru n=4 gradul minim pentru a nu se
% supraantrena aproximarile
if n==4
    figure
mesh(y_aprox1_id)
title("Aproximare si identificare")

figure
mesh(y_aprox1_val)
title("Aproximare si validare")
end
    
%MSE pentru identificare
e1=ones(N, 1); %matrice care sa stocheze toate valorile e1
for k=1:N
e1(k)=id.Y(k)-y_aprox1_id(k);
end
MSE1(n)=1/N*sum(e1.^2);

%MSE pentru validare
e2=ones(M, 1); %matrice care sa stocheze toate valorile e2 
for K=1:M
e2(K)=val.Y(K)-y_aprox1_val(K);
end
MSE2(n)=1/M*sum(e2.^2);
%functie pentru calcularea punctului minim si gradului minim a erorii medii
%patratice de validare
[minim,min_gr]=min(MSE2);
end
%afisarea graficelor pentru erori
figure
plot(1:n,MSE1)
title("Eroarea Medie Patratica 1")

figure
plot(1:n,MSE2)
title("Eroarea Medie Patratica 2")
%afisarea in consola a punctului si gradului minim
fprintf('MSE MINIM ESTE IN PUNCTUL:%f \nmin grad%d',min(MSE2),min_gr)