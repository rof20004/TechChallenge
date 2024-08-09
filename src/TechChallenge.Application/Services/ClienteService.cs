﻿using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Domain.Interfaces.Services;

namespace TechChallenge.Application.Services;
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<int> CreateCliente(string cpf, string email, string nome, string telefone, string endereco)
    {
        if (await _clienteRepository.ExistCliente(cpf))
        {
            return 0;
        }

        Cliente cliente = new Cliente()
        {
            CPF = cpf,
            Email = email,
            Nome = nome,
            Telefone = telefone,
            Endereco = endereco    
        };

        await _clienteRepository.CreateCliente(cliente);

        return (await _clienteRepository.GetCliente(cpf)).Id;
    }

    public async Task<Cliente> GetCliente(string cpf)
    {
        return await _clienteRepository.GetCliente(cpf);
    }

    public string DeleteCliente(Cliente cliente)
    {
        return _clienteRepository.DeleteCliente(cliente);
    }
}
