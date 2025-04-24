import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { EmpresasComponent } from './components/empresas/empresas.component';
import { MotoristasComponent } from './components/motoristas/motoristas.component';
import { VeiculosComponent } from './components/veiculos/veiculos.component';
import { ViagensComponent } from './components/viagens/viagens.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { EmpresaDetalheComponent } from './components/empresas/empresa-detalhe/empresa-detalhe.component';
import { EmpresaListaComponent } from './components/empresas/empresa-lista/empresa-lista.component';
import { MotoristaListaComponent } from './components/motoristas/motorista-lista/motorista-lista.component';
import { MotoristaDetalheComponent } from './components/motoristas/motorista-detalhe/motorista-detalhe.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'empresas', redirectTo: 'empresas/lista' },
    { 
        path: 'empresas', component: EmpresasComponent,
        children: [
            { path: 'detalhe/:id', component: EmpresaDetalheComponent },
            { path: 'detalhe', component: EmpresaDetalheComponent },
            { path: 'lista', component: EmpresaListaComponent}
        ]
    },
    { path: 'motoristas', redirectTo: 'motoristas/lista'},
    { 
        path: 'motoristas', component: MotoristasComponent,
        children: [
            { path: 'detalhe/:id', component: MotoristaDetalheComponent},
            { path: 'detalhe', component: MotoristaDetalheComponent},
            { path: 'lista', component: MotoristaListaComponent}
        ]
    },
    { path: 'veiculos', component: VeiculosComponent },
    { path: 'viagens', component: ViagensComponent },
    { path: 'usuarios', component: UsuariosComponent},
    { path: 'login', component: LoginComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
