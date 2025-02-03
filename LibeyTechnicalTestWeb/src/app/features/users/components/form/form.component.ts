import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { DocumentTypeService } from "src/app/core/service/documenttype.service";
import { ProvinceService } from "src/app/core/service/province.service";
import { RegionService } from "src/app/core/service/region.service";
import { UbigeoService } from "src/app/core/service/ubigeo.service";
import { DocumentType, DocumentTypeResponse } from "src/app/shared/models/documenttype";
import { Province, ProvinceResponse } from "src/app/shared/models/province";
import { Region, RegionResponse } from "src/app/shared/models/region";
import { Ubigeo, UbigeoResponse } from "src/app/shared/models/ubigeo";
import { UserUpdateorCreateCommand } from "../../models/libeyuser";
import { libeyuserService } from "../../services/libeyuser/libeyuser.service";
import Swal from "sweetalert2";
import { Router } from "@angular/router";

@Component({
	selector: "app-form",
	templateUrl: "./form.component.html",
	styleUrls: ["./form.component.css"],
})
export class FormUser implements OnInit {
	@Input() documentNumber: string = "";
	userForm!: FormGroup;

	documentTypes: DocumentType[] = [];
	regions: Region[] = [];
	provinces: Province[] = [];
	provincesUI: Province[] = [];
	ubigeos: Ubigeo[] = [];
	ubigeosUI: Ubigeo[] = [];

	constructor(
		private libeyuserService: libeyuserService,
		private documentTypeservice: DocumentTypeService,
		private provinceService: ProvinceService,
		private regionService: RegionService,
		private ubigeoService: UbigeoService,
		private router: Router
	) {
		this.initializeForm()
		this.loadDocumentTypes()
		this.loadRegions()
		this.loadProvinces()
		this.loadUbigeos()
	}

	ngOnInit(): void { }

	private getUser(): void {
		if (this.documentNumber) {
			this.libeyuserService.getFindResponse(this.documentNumber).subscribe({
				next: data => this.handleUser(data),
				error: err => console.error('Error fetching user', err)
			});
		}
	}

	private handleUser(response: any): void {
		if (response && response.data) {
			const user = response.data;

			if (this.provinces.length > 0 && this.ubigeos.length > 0) {
				this.changeRegion(user?.regionCode);
				this.changeProvince(user?.provinceCode);
			}

			this.userForm.
				get('documentTypeId')?.setValue(user.documentTypeId);
			this.userForm.
				get('documentNumber')?.setValue(user.documentNumber);
			this.userForm.
				get('name')?.setValue(user.name);
			this.userForm.
				get('fathersLastName')?.setValue(user.fathersLastName);
			this.userForm.
				get('mothersLastName')?.setValue(user.mothersLastName);
			this.userForm.
				get('address')?.setValue(user.address);
			this.userForm.
				get('regionCode')?.setValue(user.regionCode);
			this.userForm.
				get('provinceCode')?.setValue(user.provinceCode);
			this.userForm.
				get('ubigeoCode')?.setValue(user.ubigeoCode);
			this.userForm.
				get('phone')?.setValue(user.phone);
			this.userForm.
				get('email')?.setValue(user.email);
			this.userForm.
				get('password')?.setValue(user.password);
			this.userForm.
				get('confirmedPassword')?.setValue(user.password);
		} else {
			console.warn('No found or insufficient data');
		}
	}

	private initializeForm(): void {
		this.userForm = new FormGroup({  // Usamos FormGroup para agrupar los FormControls
			documentTypeId: new FormControl('', Validators.required),
			documentNumber: new FormControl('', Validators.required),
			name: new FormControl('', Validators.required),
			fathersLastName: new FormControl('', Validators.required),
			mothersLastName: new FormControl('', Validators.required),
			address: new FormControl('', Validators.required),
			regionCode: new FormControl('', Validators.required),
			provinceCode: new FormControl('', Validators.required),
			ubigeoCode: new FormControl('', Validators.required),
			phone: new FormControl('', Validators.required),
			email: new FormControl('', [Validators.required, Validators.email]),
			password: new FormControl('', [Validators.required]),
			confirmedPassword: new FormControl('', [Validators.required]),
			active: new FormControl(true)
		});
	}

	private loadDocumentTypes(): void {
		this.documentTypeservice.getListAll().subscribe({
			next: data => this.handleDocumentTypes(data),
			error: err => console.error('Error fetching data', err)
		});
	}

	private handleDocumentTypes(response: DocumentTypeResponse): void {
		if (response && response.data && response.data.length > 0) {
			this.documentTypes = response.data;
		} else {
			console.warn('No found or insufficient data');
		}
	}

	private loadProvinces(): void {
		this.provinceService.getListAll().subscribe({
			next: data => this.handleProvinces(data),
			error: err => console.error('Error fetching provinces', err)
		});
	}

	private handleProvinces(response: ProvinceResponse): void {
		if (response && response.data && response.data.length > 0) {
			this.provinces = response.data;
		} else {
			console.warn('No provinces found or insufficient data');
		}
	}

	private loadRegions(): void {
		this.regionService.getListAll().subscribe({
			next: data => this.handleRegions(data),
			error: err => console.error('Error fetching regions', err)
		});
	}

	private handleRegions(response: RegionResponse): void {
		if (response && response.data && response.data.length > 0) {
			this.regions = response.data;
		} else {
			console.warn('No regions found or insufficient data');
		}
	}

	private loadUbigeos(): void {
		this.ubigeoService.getListAll().subscribe({
			next: data => this.handleUbigeos(data),
			error: err => console.error('Error fetching ubigeos', err)
		});
	}

	private handleUbigeos(response: UbigeoResponse): void {
		if (response && response.data && response.data.length > 0) {
			this.ubigeos = response.data;
		} else {
			console.warn('No ubigeos found or insufficient data');
		}

		this.getUser()
	}

	public changeRegion(regionCode: string): void {
		this.provincesUI = this.provinces.filter(province => province.regionCode === regionCode);
		this.userForm.get('provinceCode')?.setValue('');
		this.userForm.get('ubigeoCode')?.setValue('');
	}

	public changeProvince(provinceCode: string): void {
		this.ubigeosUI = this.ubigeos.filter(ubigeo => ubigeo.provinceCode === provinceCode);
		this.userForm.get('ubigeoCode')?.setValue('');
	}

	private addLibeyuser(userCommand: UserUpdateorCreateCommand): void {
		this.libeyuserService.postCreate(userCommand).subscribe({
			next: () => {
				Swal.
					fire('Usuario agregado', 'El usuario ha sido creado correctamente', 'success');
				this.router.navigate(['/user/list']);
			},
			error: () => Swal.fire('Error', 'Error al agregar usuario', 'error')
		});
	}

	private updateLibeyuser(userCommand: UserUpdateorCreateCommand): void {
		this.libeyuserService.putUpdate(userCommand).subscribe({
			next: () => {
				Swal.
					fire('Usuario actualizado', 'El usuario ha sido actualizado correctamente', 'success');
				this.router.navigate(['/user/list']);
			},
			error: () => Swal.fire('Error', 'Error al editar usuario', 'error')
		});
	}

	isValidatedForm(): boolean {
		const formValues = this.userForm.value;
		if (this.userForm.invalid) {
			Swal.fire('Error', 'El formulario tiene campos requeridos', 'error');
			return false;
		} else if (formValues.email.length > 20) {
			Swal.fire('Error', 'El correo no puede tener más de 20 caracteres por truncamiento en base de datos', 'error');
			return false;
		} else if (formValues.password !== formValues.confirmedPassword) {
			Swal.fire('Error', 'Las contraseñas no coinciden', 'error');
			return false;
		} else {
			return true;
		}
	}

	submit() {
		if (!this.isValidatedForm()) return;

		const formValues = this.userForm.value;
		const userCommand: UserUpdateorCreateCommand = {
			documentNumber: formValues.documentNumber,
			documentTypeId: formValues.documentTypeId,
			name: formValues.name,
			fathersLastName: formValues.fathersLastName,
			mothersLastName: formValues.mothersLastName,
			address: formValues.address,
			ubigeoCode: formValues.ubigeoCode,
			phone: formValues.phone,
			email: formValues.email,
			password: formValues.password,
			active: formValues.active
		};

		if (this.documentNumber) {
			this.updateLibeyuser(userCommand);
		} else {
			this.addLibeyuser(userCommand);
		}
	}

	clearForm() {
		this.userForm.reset();
	}
}