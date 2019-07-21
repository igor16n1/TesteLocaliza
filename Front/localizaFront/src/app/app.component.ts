import { Component, OnInit } from "@angular/core";
import { UsuarioService } from "./Service/usuario.service";
import { UsuarioPosicaoDTO } from "./DTO/usuario-posicao-dto";
import { UsuarioAmigosDTO } from "./DTO/usuario-amigos-dto";
import { AmigoDTO } from "./DTO/amigo-dto";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.styl"]
})
export class AppComponent implements OnInit {
  usuarioPosicaoDTO: UsuarioPosicaoDTO[];
  usuarioAmigosDTO: UsuarioAmigosDTO[];
  amigoDTO: AmigoDTO[];
  usuarioID: number = 0;
  constructor(private usuarioService: UsuarioService) {}
  ngOnInit() {
    this.usuarioService.ConsultarTodosUsuarios().subscribe(data => {
      this.usuarioPosicaoDTO = data;
    });
  }
  ConsultarUsuarioAmigos(usuarioID: number) {
    this.usuarioID = usuarioID;
    this.usuarioService.ConsultarUsuarioAmigos(usuarioID).subscribe(data => {
      this.usuarioAmigosDTO = data;
    });
  }
  ConsultarAmigosPosicoes(usuarioAmigoID: number) {
    this.usuarioService
      .ConsultarAmigosPosicoes(this.usuarioID, usuarioAmigoID)
      .subscribe(data => {
        this.amigoDTO = data;
        console.log(this.amigoDTO);        
      });
  }
}
