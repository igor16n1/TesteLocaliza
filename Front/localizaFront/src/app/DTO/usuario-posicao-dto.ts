import { IUsuarioPosicaoDTO } from '../Interface/iusuario-posicao-dto';

export class UsuarioPosicaoDTO implements IUsuarioPosicaoDTO {
    id: number;
    usuario_Nome: string;
    posicao_Latitude: number;
    posicao_Longitude: number;
}
