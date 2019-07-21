import { IUsuarioAmigosDTO } from '../Interface/iusuario-amigos-dto';

export class UsuarioAmigosDTO implements IUsuarioAmigosDTO {
    iDAmigo: number;
    usuario_Nome: string;
    posicao_Latitude: number;
    posicao_Longitude: number;
}
