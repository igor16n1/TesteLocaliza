import { IAmigoDTO } from '../Interface/iamigo-dto';

export class AmigoDTO implements IAmigoDTO {
    distancia: number;
    idAmigo: number;
    usuario_Nome: string;
    posicao_Latitude: number;
    posicao_Longitude: number;
}
