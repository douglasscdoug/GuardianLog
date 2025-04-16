import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { MotoristasComponent } from './components/motoristas/motoristas.component';
import { VeiculosComponent } from './components/veiculos/veiculos.component';
import { ViagensComponent } from './components/viagens/viagens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'empresas', component: EmpresasComponent },
    { path: 'motoristas', component: MotoristasComponent },
    { path: 'veiculos', component: VeiculosComponent },
    { path: 'viagens', component: ViagensComponent },
    { path: 'usuarios', component: UsuariosComponent},
    { path: 'login', component: LoginComponent}
];
